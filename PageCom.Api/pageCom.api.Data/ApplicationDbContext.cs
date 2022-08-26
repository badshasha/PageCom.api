using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using PageCome.Api.Demain.BaseDomain;
using PageCome.Api.Demain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pageCom.api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        
        public override int SaveChanges() // ones modified statement recieve this method automatically trigger form the system 
        {
            foreach (var entity in ChangeTracker.Entries<BaseDomainInfo>())
            {
                entity.Entity.UpdateDateTime = DateTime.Now;
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.AddDateTime = DateTime.Now;
                }

            }

            return base.SaveChanges();
        }
        
        public DbSet<Book> Books { get; set; }
        
    }
}
