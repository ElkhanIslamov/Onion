using Core.Entities;
using Core.Entities.Common;
using Core.Entities.Identity;
using DataAccess.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccess.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}
	public DbSet<Product> Products { get; set; } = null!;
	public DbSet<Category> Categories { get; set; } = null!;
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
		base.OnModelCreating(modelBuilder);
	}
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
		var entries = ChangeTracker.Entries<BaseEntity>();
		foreach (var entry in entries) 
		{
			if(entry.State == EntityState.Added)
			{
				entry.Entity.CreatedDate = DateTime.UtcNow;
				entry.Entity.UpdatedDate = DateTime.UtcNow;
			}
			else if (entry.State == EntityState.Modified)
			{
				entry.Entity.UpdatedDate = DateTime.UtcNow;
			}
		}
        return base.SaveChangesAsync(cancellationToken);
    }

};
