using Application.Interfaces.Context;
using Common.Priority;
using Common.Status;
using Domain.Attributes;
using Domain.Entites.Cart;
using Domain.Entites.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBaseContext
{
    public class DataBaseContextMain: IdentityDbContext<Users>, IDataBaseContext
    {
        public DataBaseContextMain(DbContextOptions<DataBaseContextMain> options):base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StatusInCarts> StatusInCarts { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<PriorityInCarts> PriorityInCarts { get; set; }

       

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            HasKey(Builder);
            RenameTable(Builder);
            SeedData(Builder);
            HasqueryFilter(Builder);

            foreach (var entityType in Builder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditTableAttribute), true).Length > 0)
                {
                    Builder.Entity(entityType.Name).Property<DateTime>("InsertTime");
                    Builder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    Builder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    Builder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                }
            }
           
        }
        private  void HasqueryFilter(ModelBuilder builder)
        {
            builder.Entity<Cart>()
                 .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
        }
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

        #region Seed Data
        public void SeedData(ModelBuilder Builder)
        {
            Builder.Entity<Status>().HasData(new Status { Id = 1, Name = nameof(CartInStatus.Suspension) });
            Builder.Entity<Status>().HasData(new Status { Id = 2, Name = nameof(CartInStatus.NoStarted) });
            Builder.Entity<Status>().HasData(new Status { Id = 3, Name = nameof(CartInStatus.InProgress) });
            Builder.Entity<Status>().HasData(new Status { Id = 4, Name = nameof(CartInStatus.InComplete) });
            Builder.Entity<Priority>().HasData(new Priority { Id = 1, Name = nameof(CartInPriority.General) });
            Builder.Entity<Priority>().HasData(new Priority { Id = 2, Name = nameof(CartInPriority.Urgent) });
            Builder.Entity<Priority>().HasData(new Priority { Id = 3, Name = nameof(CartInPriority.Critical) });
        }
        #endregion
        #region Save Change
        public override int SaveChanges()
        {
            var modifiedEntires = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Added ||
                p.State == EntityState.Modified ||
                p.State == EntityState.Deleted
                );
            foreach (var item in modifiedEntires)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

                var InsertTime = entityType.FindProperty("InsertTime");
                var UpdateTime = entityType.FindProperty("UpdateTime");
                var IsRemoved = entityType.FindProperty("IsRemoved");
                var RemoveTime = entityType.FindProperty("RemoveTime");
                if (item.State == EntityState.Added && InsertTime != null)
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Modified && UpdateTime != null)
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Deleted && IsRemoved != null && RemoveTime != null)
                {
                    item.Property("IsRemoved").CurrentValue = true;
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.State = EntityState.Modified;

                }

            }
            return base.SaveChanges();
        }

        

        #endregion
    }
}
