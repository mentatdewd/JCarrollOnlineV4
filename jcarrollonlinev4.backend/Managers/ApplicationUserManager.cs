﻿using jcarrollonlinev4.backend.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Owin;

namespace JCarrollOnlineV2
{
    public class ApplicationUserManager //: UserManager<ApplicationUser>
    {
        private bool _disposed;
        //public ApplicationUserManager() : base(store)) { }
        //public static ApplicationUserManager Create(ApplicationUser applicationUser)
        //{
        //    //#pragma warning disable CA2000 // Dispose objects before losing scope If this is closed when leaving then the logged in user is lost
        //    //            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context.Get<JCarrollOnlineV4DbContext>());
        //    //#pragma warning restore CA2000 // Dispose objects before losing scope

        //    var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<AppUsersDbContext>()));
            // Configure validation logic for usernames
            //manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = false,
            //    RequireUniqueEmail = true
            //};

            // Configure validation logic for passwords
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = true,
            //    RequireDigit = true,
            //    RequireLowercase = true,
            //    RequireUppercase = true,
            //};

            // Configure user lockout defaults
            //manager.UserLockoutEnabledByDefault = true;
            //manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            //manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            //{
            //    MessageFormat = "Your security code is {0}"
            //});
            //manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            //{
            //    Subject = "Security Code",
            //    BodyFormat = "Your security code is {0}"
            //});
            //manager.EmailService = new MailService();

            //manager.SmsService = new SmsService();
            //Microsoft.Security.DataProtection.IDataProtectionProvider dataProtectionProvider = options.DataProtectionProvider;
            //if (dataProtectionProvider != null)
            //{
            //    manager.UserTokenProvider =
            //        new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            //}

            //return manager;
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);

        //    if (!_disposed)
        //    {
        //        _disposed = true;
        //    }
        //}
    }
}