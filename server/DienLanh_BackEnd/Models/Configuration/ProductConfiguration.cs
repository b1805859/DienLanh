using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DienLanh_BackEnd.Models.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(e => e.ProductID).HasMaxLength(10).IsUnicode(false).HasColumnName("ProductID");
            builder.Property(e => e.Title).HasMaxLength(255).IsUnicode(true).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(1000).IsUnicode(true);
            builder.Property(e => e.Price).HasMaxLength(15).IsUnicode(false);
            builder.Property(e => e.CreatedDate).IsUnicode(false);
            builder.Property(e => e.UpdatedDate).IsUnicode(false);

            //Relationship
            builder.HasOne(c => c.ProductCategory).WithMany(e => e.Products);
        }
    }
}
