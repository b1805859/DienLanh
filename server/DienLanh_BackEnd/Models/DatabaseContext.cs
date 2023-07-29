using DienLanh_BackEnd.Models;
using DienLanh_BackEnd.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Models.Configuration;

namespace WebAPI_JWT_NET6_Base.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<Employee>? Employees { get; set; }
        public virtual DbSet<UserInfo>? UserInfos { get; set; }
        public virtual DbSet<Service>? Services { get; set; }
        public virtual DbSet<ServiceCategory>? ServiceCategorys { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<ProductCategory>? ProductCategorys { get; set; }

        public virtual DbSet<Booking>? Bookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new EmployeeConfiguration().Configure(modelBuilder.Entity<Employee>());
            new UserInfoConfiguration().Configure(modelBuilder.Entity<UserInfo>());
            new BookingConfiguration().Configure(modelBuilder.Entity<Booking>());
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new ProductCategoryConfiguration().Configure(modelBuilder.Entity<ProductCategory>());
            new ServiceConfiguration().Configure(modelBuilder.Entity<Service>());
            new ServiceCategoryConfiguration().Configure(modelBuilder.Entity<ServiceCategory>());


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
