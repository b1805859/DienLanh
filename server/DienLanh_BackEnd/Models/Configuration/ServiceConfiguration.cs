using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DienLanh_BackEnd.Models.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");
            builder.Property(e => e.ServiceID).HasMaxLength(10).IsUnicode(false).HasColumnName("ServiceID");
            builder.Property(e => e.Title).HasMaxLength(255).IsUnicode(false).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(255).IsUnicode(false);
            builder.Property(e => e.Price).HasMaxLength(255).IsUnicode(false);
            builder.Property(e => e.CreatedDate).IsUnicode(false);
            builder.Property(e => e.UpdatedDate).IsUnicode(false);


        }
    }
}
