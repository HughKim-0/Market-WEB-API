using Market_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Market_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductLocation> ProductLocations { get; set; }
        public DbSet<ProductPayment> ProductPayments { get; set; }
        public IEnumerable<object> Locations { get; internal set; }
        public IEnumerable<object> Payments { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductLocation>().HasKey(pl => new { pl.ProductId, pl.LocationId });
            modelBuilder.Entity<ProductLocation>().HasOne(p => p.Product).WithMany(pl => pl.ProductLocations).HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductLocation>().HasOne(p => p.Location).WithMany(pl => pl.ProductLocations).HasForeignKey(l => l.LocationId);

            modelBuilder.Entity<ProductPayment>().HasKey(pm => new { pm.ProductId, pm.PaymentId });
            modelBuilder.Entity<ProductPayment>().HasOne(p => p.Product).WithMany(pm => pm.ProductPayments).HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductPayment>().HasOne(p => p.Payment).WithMany(pm => pm.ProductPayments).HasForeignKey(m => m.PaymentId);
        }
    }
}
