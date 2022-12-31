using Domain.Entites.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBaseContext
{
    public class IdentityDataBaseContext : IdentityDbContext<Users>
    {
        public IdentityDataBaseContext(DbContextOptions<IdentityDataBaseContext> options) : base(options)
        {

        }

        #region  Model Creat
        protected override void OnModelCreating(ModelBuilder builder)
        {
            HasKey(builder);
            RenameTable(builder);
        }
        #endregion

        #region key For Identity Table
        private void HasKey(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });
            builder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.RoleId, p.UserId });
            builder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
        }

        #endregion


        #region Rename Table
        private void RenameTable(ModelBuilder builder)
        {
            builder.Entity<IdentityUser<string>>().ToTable("Users", "identity");
            builder.Entity<IdentityRole<string>>().ToTable("Roles", "identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "identity");
        }
        #endregion


    }



}
