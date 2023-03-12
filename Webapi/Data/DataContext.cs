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
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(x => x.OrderDetails)
                .WithOne(x => x.Order);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
    
}
