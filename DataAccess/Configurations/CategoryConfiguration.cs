using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.Property(c=>c.Name).IsRequired(true).HasMaxLength(100);
		builder.HasMany(c => c.Products).WithOne(p => p.Category);
	}
}
