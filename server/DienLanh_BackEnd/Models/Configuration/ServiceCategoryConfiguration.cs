using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DienLanh_BackEnd.Models.Configuration
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.ToTable("ServiceCategory");
            builder.Property(e => e.ServiceCategoryID).HasMaxLength(10).IsUnicode(false).HasColumnName("ServiceCategoryID");
            builder.Property(e => e.Title).HasMaxLength(255).IsUnicode(false).IsRequired();
            builder.Property(e => e.CreatedDate).IsUnicode(false);
            builder.Property(e => e.UpdatedDate).IsUnicode(false);

            //Relationship
            builder.HasMany(c => c.Services).WithOne(e => e.ServiceCategory);
        }
    }
}