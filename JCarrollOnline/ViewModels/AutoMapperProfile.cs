using AutoMapper;
using DAL.Core;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace JCarrollOnline.ViewModels
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>()
                   .ForMember(d => d.Roles, map => map.Ignore());
            CreateMap<UserViewModel, ApplicationUser>()
                .ForMember(d => d.Roles, map => map.Ignore())
                .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

            CreateMap<ApplicationUser, UserEditViewModel>()
                .ForMember(d => d.Roles, map => map.Ignore());
            CreateMap<UserEditViewModel, ApplicationUser>()
                .ForMember(d => d.Roles, map => map.Ignore())
                .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

            CreateMap<ApplicationUser, UserPatchViewModel>()
                .ReverseMap();

            CreateMap<ApplicationRole, RoleViewModel>()
                .ForMember(d => d.Permissions, map => map.MapFrom(s => s.Claims))
                .ForMember(d => d.UsersCount, map => map.MapFrom(s => s.Users != null ? s.Users.Count : 0))
                .ReverseMap();
            CreateMap<RoleViewModel, ApplicationRole>()
                .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

            CreateMap<IdentityRoleClaim<string>, ClaimViewModel>()
                .ForMember(d => d.Type, map => map.MapFrom(s => s.ClaimType))
                .ForMember(d => d.Value, map => map.MapFrom(s => s.ClaimValue))
                .ReverseMap();

            CreateMap<ApplicationPermission, PermissionViewModel>()
                .ReverseMap();

            CreateMap<IdentityRoleClaim<string>, PermissionViewModel>()
                .ConvertUsing(s => (PermissionViewModel)ApplicationPermissions.GetPermissionByValue(s.ClaimValue));

            CreateMap<Forum, ForaViewModel>().ReverseMap()
                                .ForMember(d => d.Id, map => map.Condition(src => src.Id != -1))
                                .ForMember(d => d.ForumThreadEntries, map => map.Ignore())
            .ForMember(d => d.ForumModerators, map => map.Ignore());

            CreateMap<ForumThreadEntry, ForumThreadEntryViewModel>()
                                       .ReverseMap()
                                       .ForMember(d => d.Id, map => map.Condition(src => src.Id != -1))
                                       .ForMember(d => d.Author, map => map.Ignore())
                                       .ForPath(d => d.Author.Email, opts => opts.MapFrom(source => source.AuthorEmail))
                                       .ForPath(d => d.Author.ForumPostCount, opts => opts.MapFrom(source => source.AuthorForumPostCount))
                                       .ForMember(d => d.Forum, map => map.Ignore());

            CreateMap<Micropost, MicropostViewModel>().ReverseMap();

            CreateMap<ForumThreadEntry, ForumThreadsViewModel>().ReverseMap();
        }
    }
}
