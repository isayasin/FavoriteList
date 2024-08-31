using FavortieList.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FavortieList.WebAPI.Context;

public class ApplicationDbContext : DbContext
{
    //private readonly DbContext dbContext ;

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        //dbContext = new DbContext(options);
    }

    public DbSet<FavList> favLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<FavList>().Property(x => x.Star).IsRequired();
        modelBuilder.Entity<FavList>().Property(x => x.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<FavList>().Property(x => x.ContentType).IsRequired().HasMaxLength(20);
        modelBuilder.Entity<FavList>().ToTable(f => f.HasCheckConstraint("Chk_Fav_Star", "[Star]<=5"));
    }
}
