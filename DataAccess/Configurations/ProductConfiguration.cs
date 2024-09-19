using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.Property(p=> p.Name).IsRequired(true).HasMaxLength(50);
		builder.Property(p=> p.Description).IsRequired(false).HasMaxLength(500);
		builder.Property(p => p.Price).IsRequired(true);
		builder.Property(p=>p.Rating).IsRequired(true);
		builder.Property(p=>p.CategoryId).IsRequired(false);

		builder.HasCheckConstraint("Ck_ProductPrice", "Price>0");
		builder.HasCheckConstraint("Ck_ProductRating", "Rating>=0 AND Rating <=5");
	}
}
