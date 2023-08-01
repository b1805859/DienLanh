using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DienLanh_BackEnd.Models.Configuration
{
    public class FileDetailConfiguration : IEntityTypeConfiguration<FileDetail>
    {
        public void Configure(EntityTypeBuilder<FileDetail> builder)
        {
            builder.ToTable("FileDetail");
            builder.HasKey(e => e.FileID);
            builder.Property(e => e.FileID).HasMaxLength(15).IsUnicode(false).HasColumnName("FileID");
            builder.Property(e => e.FileName).HasMaxLength(255).IsUnicode(true).IsRequired(); ;
            builder.Property(e => e.FileData).HasMaxLength(40000).IsUnicode(true).IsRequired();
            builder.Property(e => e.CreatedDate).IsUnicode(false);
            builder.Property(e => e.UpdatedDate).IsUnicode(false);
        }
    }
}
