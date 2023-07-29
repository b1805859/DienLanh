using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI_JWT_NET6_Base.Models.Configuration
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasNoKey();
            builder.ToTable("UserInfo");
            builder.Property(e => e.UserId).HasMaxLength(10).IsUnicode(false).HasColumnName("UserId");
            builder.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
            builder.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
            builder.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            builder.Property(e => e.CreatedDate).IsUnicode(false);
        }
    }
}
