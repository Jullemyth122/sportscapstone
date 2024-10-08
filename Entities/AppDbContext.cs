using Microsoft.EntityFrameworkCore;

namespace SportsCapstone.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<AdminAccount> AdminAccounts { get; set; }
        public DbSet<Product> Products { get; set; } // Add this line

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminAccount>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<AdminAccount>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            // Configure the Product entity
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Brand)
                .IsRequired(); // Example for Brand

            modelBuilder.Entity<Product>()
                .Property(p => p.Quantity)
                .IsRequired(); // Example for Quantity

            modelBuilder.Entity<Product>()
                .Property(p => p.Type)
                .IsRequired(); // Example for Quantity
            modelBuilder.Entity<Product>()
                .Property(p => p.AgeRange)
                .IsRequired(); // Example for Quantity

            // Continue adding other configurations as necessary...

            base.OnModelCreating(modelBuilder);
        }

    }
}
