using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Base;

public class DataBaseContext: DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Category> Categories {get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserCards> UserCards { get; set; }
    public DbSet<UserDestinationCategoryMap> UserDestinationCategoryMaps { get; set; }

    public DataBaseContext(DbContextOptions options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserCards>()
            .HasKey(uc => new { uc.UserId, uc.CardId });

        modelBuilder.Entity<UserDestinationCategoryMap>()
            .HasKey(udcm => new { udcm.UserId, udcm.CategoryId, udcm.DestinationId });
    }


}