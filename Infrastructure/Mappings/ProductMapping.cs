using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Quantity).IsRequired();
            builder.Property(e => e.Price).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.CategoryId).IsRequired();
        }
    }
}
