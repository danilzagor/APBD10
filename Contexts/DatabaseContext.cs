using Microsoft.EntityFrameworkCore;

namespace APBD10.Models;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    
    
    
    
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<Product>()
        //     .HasMany(e => e.Categories)
        //     .WithMany(e => e.Products)
        //     .UsingEntity("Products_Categories");
        
        modelBuilder.Entity<Product>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Products)
            .UsingEntity("Products_Categories",
                l => l.HasOne(typeof(Category)).WithMany().HasForeignKey("FK_category"),
                r => r.HasOne(typeof(Product)).WithMany().HasForeignKey("FK_product"));
        modelBuilder.Entity<ShoppingCart>().HasKey(sc => new { sc.AccountId, sc.ProductId });
    }
}