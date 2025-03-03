using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductsConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Description)
            .HasMaxLength(2500);

        builder.Property(p => p.Category)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Image)
            .HasMaxLength(255);

        builder.Property(p => p.RatingRate)
            .HasColumnType("decimal(3,2)");

        builder.Property(p => p.RatingCount)
            .IsRequired()
            .HasColumnType("bigint");

        builder.Property(p => p.Active)
            .IsRequired()
            .HasColumnType("boolean");

        builder.Property(p => p.DeactivationDate)
            .IsRequired(false);
    }
}
