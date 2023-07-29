﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_JWT_NET6_Base.Models;

#nullable disable

namespace DienLanh_BackEnd.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230728071146_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DienLanh_BackEnd.Models.Booking", b =>
                {
                    b.Property<string>("BookingID")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("BookingID");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("BookingID");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("DienLanh_BackEnd.Models.Product", b =>
                {
                    b.Property<string>("ProductID")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("ProductID");

                    b.Property<DateTime?>("CreatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Price")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProductCategoryID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.HasKey("ProductID");

                    b.HasIndex("ProductCategoryID");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("DienLanh_BackEnd.Models.ProductCategory", b =>
                {
                    b.Property<string>("ProductCategoryID")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("ProductCategoryID");

                    b.Property<DateTime?>("CreatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.HasKey("ProductCategoryID");

                    b.ToTable("ProductCategory", (string)null);
                });

            modelBuilder.Entity("DienLanh_BackEnd.Models.Service", b =>
                {
                    b.Property<string>("ServiceID")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("ServiceID");

                    b.Property<string>("BookingID")
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Price")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ServiceCategoryID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.HasKey("ServiceID");

                    b.HasIndex("BookingID");

                    b.HasIndex("ServiceCategoryID");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("DienLanh_BackEnd.Models.ServiceCategory", b =>
                {
                    b.Property<string>("ServiceCategoryID")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("ServiceCategoryID");

                    b.Property<DateTime?>("CreatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.HasKey("ServiceCategoryID");

                    b.ToTable("ServiceCategory", (string)null);
                });

            modelBuilder.Entity("WebAPI_JWT_NET6_Base.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeID")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime>("BirthDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime>("HireDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LoginID")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("MaritalStatus")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime>("ModifiedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalIDNumber")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<Guid?>("RowGuid")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("SickLeaveHours")
                        .IsUnicode(false)
                        .HasColumnType("smallint");

                    b.Property<short>("VacationHours")
                        .IsUnicode(false)
                        .HasColumnType("smallint");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("WebAPI_JWT_NET6_Base.Models.UserInfo", b =>
                {
                    b.Property<DateTime?>("CreatedDate")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UserId")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.ToTable("UserInfo", (string)null);
                });

            modelBuilder.Entity("DienLanh_BackEnd.Models.Product", b =>
                {
                    b.HasOne("DienLanh_BackEnd.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryID");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("DienLanh_BackEnd.Models.Service", b =>
                {
                    b.HasOne("DienLanh_BackEnd.Models.Booking", null)
                        .WithMany("Service")
                        .HasForeignKey("BookingID");

                    b.HasOne("DienLanh_BackEnd.Models.ServiceCategory", "ServiceCategory")
                        .WithMany("Services")
                        .HasForeignKey("ServiceCategoryID");

                    b.Navigation("ServiceCategory");
                });

            modelBuilder.Entity("DienLanh_BackEnd.Models.Booking", b =>
                {
                    b.Navigation("Service");
                });

            modelBuilder.Entity("DienLanh_BackEnd.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DienLanh_BackEnd.Models.ServiceCategory", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}