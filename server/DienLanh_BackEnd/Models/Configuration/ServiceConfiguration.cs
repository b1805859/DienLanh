using DienLanh_BackEnd.Common;
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
            builder.Property(e => e.Image).HasMaxLength(255).IsUnicode(true);
            builder.Property(e => e.Title).HasMaxLength(255).IsUnicode(true).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(5000).IsUnicode(true);
            builder.Property(e => e.Price).HasMaxLength(255).IsUnicode(false);
            builder.Property(e => e.CreatedDate).IsUnicode(false);
            builder.Property(e => e.UpdatedDate).IsUnicode(false);

            //Seeding Data
            builder.HasData(
                new Service { ServiceID = C_Function.randomID(), Title = "Tháo, lắp máy lạnh", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new Service { ServiceID = C_Function.randomID(), Title = "Tháo, lắp máy giặt", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new Service { ServiceID = C_Function.randomID(), Title = "Tháo, lắp máy nước nóng", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new Service { ServiceID = C_Function.randomID(), Title = "Tháo lắp vận chuyển tủ lạnh", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new Service { ServiceID = C_Function.randomID(), Title = "Vệ sinh máy lạnh", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new Service { ServiceID = C_Function.randomID(), Title = "Vệ sinh máy giặt", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new Service { ServiceID = C_Function.randomID(), Title = "Sửa chữa máy lạnh", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new Service { ServiceID = C_Function.randomID(), Title = "Sửa chữa máy giặt", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new Service { ServiceID = C_Function.randomID(), Title = "Sửa chữa tủ lạnh", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
            );
        }
    }
}
