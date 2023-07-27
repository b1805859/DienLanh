using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI_JWT_NET6_Base.Models.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
            builder.Property(e => e.NationalIDNumber).HasMaxLength(15).IsUnicode(false);
            builder.Property(e => e.EmployeeName).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.LoginID).HasMaxLength(256).IsUnicode(false);
            builder.Property(e => e.JobTitle).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.BirthDate).IsUnicode(false);
            builder.Property(e => e.MaritalStatus).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.HireDate).IsUnicode(false);
            builder.Property(e => e.VacationHours).IsUnicode(false);
            builder.Property(e => e.SickLeaveHours).IsUnicode(false);
            builder.Property(e => e.RowGuid).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.ModifiedDate).IsUnicode(false);
        }
    }
}
