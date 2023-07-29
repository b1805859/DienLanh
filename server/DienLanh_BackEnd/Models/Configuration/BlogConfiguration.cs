using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DienLanh_BackEnd.Models.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blog");
            builder.Property(e => e.BlogID).HasMaxLength(10).IsUnicode(false).HasColumnName("BlogID");
            builder.Property(e => e.Title).HasMaxLength(255).IsUnicode(true).IsRequired();
            builder.Property(e => e.Source).HasMaxLength(255).IsUnicode(false).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(5000).IsUnicode(true);
            builder.Property(e => e.CreatedDate).IsUnicode(false);
            builder.Property(e => e.UpdatedDate).IsUnicode(false);

        }
    }
}