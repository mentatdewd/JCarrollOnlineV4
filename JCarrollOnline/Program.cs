using DAL;
using DAL.Core;
using DAL.Core.Interfaces;
using DAL.Models;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using JCarrollOnline.Authorization;
using JCarrollOnline.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AppPermissions = DAL.Core.ApplicationPermissions;

namespace JCarrollOnline
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            AddServices(builder);// Add services to the container.

            WebApplication app = builder.Build();
            ConfigureRequestPipeline(app); // Configure the HTTP request pipeline.

            SeedDatabase(app); //Seed initial database

            app.Run();
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            string authServerUrl = builder.Configuration["AuthServerUrl"].TrimEnd('/');

            string migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name; //JCarrollOnline

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly)));

            // add identity
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity options and password complexity here
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // User settings
                options.User.RequireUniqueEmail = true;

                //// Password settings
                //options.Password.RequireDigit = true;
                //options.Password.RequiredLength = 8;
                //options.Password.RequireNonAlphanumeric = false;
                //options.Password.RequireUppercase = true;
                //options.Password.RequireLowercase = false;

                //// Lockout settings
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                //options.Lockout.MaxFailedAccessAttempts = 10;
            });

            // Adds IdentityServer.
            builder.Services.AddIdentityServer(o =>
            {
                o.IssuerUri = authServerUrl;
            })
              .AddInMemoryPersistedGrants()
              // To configure IdentityServer to use EntityFramework (EF) as the storage mechanism
              .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
              .AddInMemoryApiScopes(IdentityServerConfig.GetApiScopes())
              .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
              .AddInMemoryClients(IdentityServerConfig.GetClients())
              .AddAspNetIdentity<ApplicationUser>()
              .AddProfileService<ProfileService>();

            builder.Services.AddAuthentication(o =>
            {
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.Authority = authServerUrl; // base-address of your identityserver
                    options.TokenValidationParameters.ValidateAudience = false;
                    options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
                    options.MapInboundClaims = false;
                    options.TokenValidationParameters.NameClaimType = JwtClaimTypes.Name;
                    options.TokenValidationParameters.RoleClaimType = JwtClaimTypes.Role;
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.ViewAllUsersPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, AppPermissions.ViewUsers));
                options.AddPolicy(Policies.ManageAllUsersPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, AppPermissions.ManageUsers));

                options.AddPolicy(Policies.ViewAllRolesPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, AppPermissions.ViewRoles));
                options.AddPolicy(Policies.ViewRoleByRoleNamePolicy, policy => policy.Requirements.Add(new ViewRoleAuthorizationRequirement()));
                options.AddPolicy(Policies.ManageAllRolesPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, AppPermissions.ManageRoles));

                options.AddPolicy(Policies.AssignAllowedRolesPolicy, policy => policy.Requirements.Add(new AssignRolesAuthorizationRequirement()));
            });

            // Add cors
            builder.Services.AddCors();

            builder.Services.AddControllersWithViews();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = IdentityServerConfig.ApiFriendlyName, Version = "v1" });
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("/connect/token", UriKind.Relative),
                            Scopes = new Dictionary<string, string>
                            {
                                { IdentityServerConfig.ApiName, IdentityServerConfig.ApiFriendlyName }
                            }
                        }
                    }
                });
            });

            builder.Services.AddAutoMapper(typeof(Program));

            // Configurations
            builder.Services.Configure<AppSettings>(builder.Configuration);

            // Business Services
            builder.Services.AddScoped<IEmailSender, EmailSender>();

            // Repositories
            builder.Services.AddScoped<IUnitOfWork, HttpUnitOfWork>();
            builder.Services.AddScoped<IAccountManager, AccountManager>();

            // Auth Handlers
            builder.Services.AddSingleton<IAuthorizationHandler, ViewUserAuthorizationHandler>();
            builder.Services.AddSingleton<IAuthorizationHandler, ManageUserAuthorizationHandler>();
            builder.Services.AddSingleton<IAuthorizationHandler, ViewRoleAuthorizationHandler>();
            builder.Services.AddSingleton<IAuthorizationHandler, AssignRolesAuthorizationHandler>();

            // DB Creation and Seeding
            builder.Services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();

            //File Logger
            builder.Logging.AddFile(builder.Configuration.GetSection("Logging"));

            //Email Templates
            EmailTemplates.Initialize(builder.Environment);
        }

        private static void ConfigureRequestPipeline(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseIdentityServer();

            app.UseRouting();
            app.UseAuthorization();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Swagger UI - JCarrollOnline";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{IdentityServerConfig.ApiFriendlyName} V1");
                c.OAuthClientId(IdentityServerConfig.SwaggerClientID);
                c.OAuthClientSecret("no_password"); //Leaving it blank doesn't work
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.Map("api/{**slug}", context =>
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return Task.CompletedTask;
            });

            app.MapFallbackToFile("index.html");
        }

        private static void SeedDatabase(WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;

                try
                {
                    IDatabaseInitializer databaseInitializer = services.GetRequiredService<IDatabaseInitializer>();
                    databaseInitializer.SeedAsync().Wait();
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogCritical(LoggingEvents.INIT_DATABASE, ex, LoggingEvents.INIT_DATABASE.Name);

                    throw new Exception(LoggingEvents.INIT_DATABASE.Name, ex);
                }
            }
        }
    }
}