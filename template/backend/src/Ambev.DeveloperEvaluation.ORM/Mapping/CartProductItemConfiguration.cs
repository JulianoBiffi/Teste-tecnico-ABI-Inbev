using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartProductItemConfiguration : IEntityTypeConfiguration<CartProductItem>
{
    public void Configure(EntityTypeBuilder<CartProductItem> builder)
    {
        builder.ToTable("CartProductItems");

        builder.HasKey(p => p.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(cpi => cpi.CartId)
            .IsRequired();

        builder.Property(cpi => cpi.ProductId)
            .IsRequired();

        builder.Property(cpi => cpi.Quantity)
            .IsRequired();

        builder.HasOne(cpi => cpi.Cart)
            .WithMany(c => c.CartProductItems)
            .HasForeignKey(cpi => cpi.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cpi => cpi.Products)
            .WithMany()
            .HasForeignKey(cpi => cpi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
