using HDISigorta.Domain.Entities.Agreements;
using HDISigorta.Domain.Entities.Common;
using HDISigorta.Domain.Entities.Customers;
using HDISigorta.Domain.Entities.Dealers;
using HDISigorta.Domain.Entities.Identities;
using HDISigorta.Domain.Entities.Maintenance;
using HDISigorta.Domain.Entities.MaintenanceCenters;
using HDISigorta.Domain.Entities.Personnels;
using HDISigorta.Domain.Entities.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HDISigorta.Persistence.Contexts
{
    public class HDISigortaDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public HDISigortaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<MaintenanceCenter> MaintenanceCenters { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Agreement> Agreements { get; set; }


        /// <summary>
        /// Entityler üzerinden yapılan değişikliklerin ya da yeni eklenen veriyi yakalayıp kayıt edildiyse createdDate i, güncellendiyse updatedDate i eklemesini sağlayacaktır.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity<Guid>>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
