using Domain.Entites.Cart;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Context
{
    public interface IDataBaseContext
    {


        DbSet<Cart> Carts { get; set; }
        DbSet <Status> Statuses { get; set; }
        DbSet<StatusInCarts> StatusInCarts {get;set;}
        DbSet<Priority> Priorities { get; set; }
        DbSet<PriorityInCarts> PriorityInCarts { get; set; }


        #region save change
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        #endregion

    }
}
