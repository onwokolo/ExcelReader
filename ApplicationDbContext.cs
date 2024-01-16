// ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public DbSet<StockPrice> StockPrice { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<StockPrice>()
    //         .HasNoKey();
    // }

    public void RecreateDatabase()
    {
        Console.WriteLine("Deleting Database if it exists...\n");
        this.Database.EnsureDeleted();

        Console.WriteLine("Recreating Database...\n");
        this.Database.EnsureCreated();
        Console.WriteLine("Database created...\n");
    }
}