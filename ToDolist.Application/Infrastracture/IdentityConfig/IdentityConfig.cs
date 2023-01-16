using Domain.Entites.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.IdentityConfig
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddidentityService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IdentityDataBaseContext>(options => options
.UseSqlServer(configuration.GetConnectionString("SecondConnection")));
            services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<IdentityDataBaseContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<CustomIdentityError>();

            services.Configure<IdentityOptions>(Options =>
            {
                Options.Password.RequireDigit=false;
                Options.Password.RequiredLength = 8;
                Options.Password.RequireLowercase=false;
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireUppercase = false;
                Options.Password.RequiredUniqueChars = 1;
                Options.User.RequireUniqueEmail = true;
                Options.Lockout.MaxFailedAccessAttempts = 5;
                Options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromDays(60);
            
            });
            return services;
        }
    }
}
