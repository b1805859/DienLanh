using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DienLanh_BackEnd.Models.Configuration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory");
            builder.Property(e => e.ProductCategoryID).HasMaxLength(10).IsUnicode(false).HasColumnName("ProductCategoryID");
            builder.Property(e => e.Title).HasMaxLength(255).IsUnicode(true).IsRequired();
            builder.Property(e => e.CreatedDate).IsUnicode(false);
            builder.Property(e => e.UpdatedDate).IsUnicode(false);

            //Relationship
            builder.HasMany(c => c.Products).WithOne(e => e.ProductCategory);
        }
    }
}
