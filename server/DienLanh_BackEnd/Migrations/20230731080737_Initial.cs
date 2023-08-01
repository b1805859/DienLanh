using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DienLanh_BackEnd.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Source = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogID);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "FileDetail",
                columns: table => new
                {
                    FileID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", maxLength: 40000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetail", x => x.FileID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductCategoryID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Price = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ServiceCategoryBlogID = table.Column<string>(type: "varchar(10)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    BookingID = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Service_Blog_ServiceCategoryBlogID",
                        column: x => x.ServiceCategoryBlogID,
                        principalTable: "Blog",
                        principalColumn: "BlogID");
                    table.ForeignKey(
                        name: "FK_Service_Booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    ProductCategoryID = table.Column<string>(type: "varchar(10)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryID");
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ServiceID", "BookingID", "CreatedDate", "Description", "Image", "Price", "ServiceCategoryBlogID", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { "1937088546", null, new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6766), null, null, null, null, "Tháo, lắp máy nước nóng", new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6767) },
                    { "2256876019", null, new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6672), null, null, null, null, "Tháo, lắp máy lạnh", new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6711) },
                    { "3239775638", null, new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6834), null, null, null, null, "Vệ sinh máy lạnh", new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6835) },
                    { "3589386588", null, new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6747), null, null, null, null, "Tháo, lắp máy giặt", new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6750) },
                    { "6826524702", null, new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6821), null, null, null, null, "Tháo lắp vận chuyển tủ lạnh", new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6822) },
                    { "7266490221", null, new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6861), null, null, null, null, "Sửa chữa máy lạnh", new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6862) },
                    { "7578872125", null, new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6892), null, null, null, null, "Sửa chữa máy giặt", new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6893) },
                    { "7772096437", null, new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6848), null, null, null, null, "Vệ sinh máy giặt", new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6849) },
                    { "9637057639", null, new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6906), null, null, null, null, "Sửa chữa tủ lạnh", new DateTime(2023, 7, 31, 15, 7, 37, 380, DateTimeKind.Local).AddTicks(6907) }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "UserId", "CreatedDate", "DisplayName", "Email", "Password", "UserName" },
                values: new object[] { "9732800313", new DateTime(2023, 7, 31, 15, 7, 37, 379, DateTimeKind.Local).AddTicks(6367), "Lê Văn Hiếu", "admin@gmail.com", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryID",
                table: "Product",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_BookingID",
                table: "Service",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceCategoryBlogID",
                table: "Service",
                column: "ServiceCategoryBlogID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDetail");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
