using DataAccess.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using Web.CustomValidators;
using Web.Localizations;
using Web.Models;

namespace Web.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {

            services.Configure <DataProtectionTokenProviderOptions>(opt =>
            {
                opt.TokenLifespan = TimeSpan.FromHours(1);
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz1234567890_@.,";

                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 3;

            })
                .AddUserValidator<UserValidator>()
                .AddPasswordValidator<PasswordValidator>()
                .AddErrorDescriber<LocalizationIdentityErrorDescriber>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<MyIdentityDbContext>();

        }
    }
}
