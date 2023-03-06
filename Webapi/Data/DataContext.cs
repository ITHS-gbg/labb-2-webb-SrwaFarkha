using Microsoft.EntityFrameworkCore;
using Webapi.Data.DataModels;

namespace Webapi.Data
{
    public class DataContext : DbContext
    {
        //conectar med databasen
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        //Skapar databastabell
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(a => a.Address)
                .WithOne(a => a.Customer)
                .HasForeignKey<Address>(c => c.CustomerId);
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
