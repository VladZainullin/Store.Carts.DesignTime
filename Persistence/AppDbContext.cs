using Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

internal sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Cart> Carts => Set<Cart>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductInCartConfiguration());
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}