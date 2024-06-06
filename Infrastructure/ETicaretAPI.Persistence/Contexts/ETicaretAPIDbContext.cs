using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        { }

        private DbSet<Product> Products { get; set; }
        private DbSet<Order> Orders { get; set; }
        private DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişikliklerin  ya da yeni eklenen verilerin yakalanmasını sağlayan proppertydir
            //Update operasyonlarında  Track edilen verileri yakalayıp elde etmemizi sağlar

            var datas =  ChangeTracker
                .Entries<BaseEntitiy>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate=DateTime.UtcNow,
                    EntityState.Modified =>data.Entity.UpdatedDate=DateTime.UtcNow,
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
