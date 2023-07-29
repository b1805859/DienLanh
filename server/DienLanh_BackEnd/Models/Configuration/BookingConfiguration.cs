using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DienLanh_BackEnd.Models.Configuration
{

    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");
            builder.Property(e => e.BookingID).HasMaxLength(10).IsUnicode(false).HasColumnName("BookingID");
            builder.Property(e => e.UserName).HasMaxLength(100).IsUnicode(false).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.PhoneNumber).HasMaxLength(12).IsUnicode(false).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(255).IsUnicode(false);
            builder.Property(e => e.CreatedDate).IsUnicode(false);
            builder.Property(e => e.UpdatedDate).IsUnicode(false);
        }
    }
}
