using BookPlatform.API.Geography.Domain.Model.Aggregates;
using BookPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BookPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Geography Context Configuration
        builder.Entity<Country>().HasKey(c => c.Id);
        builder.Entity<Country>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Country>().Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Country>().Property(c => c.Abbreviation).HasMaxLength(10);
        
        // Snake Case Convention
        builder.UseSnakeCaseNamingConvention();
    }
}