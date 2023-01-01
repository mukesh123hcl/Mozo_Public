using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class Area_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Geo_Category");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Geo_Category");

            migrationBuilder.DropColumn(
                name: "Pincode",
                table: "Geo_Category");

            migrationBuilder.DropColumn(
                name: "Geo_Category_Id",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Services",
                table: "Bookings",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Area_Name = table.Column<string>(nullable: true),
                    City_Id = table.Column<long>(nullable: false),
                    GeoCategory_Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Services",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Geo_Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Geo_Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pincode",
                table: "Geo_Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Geo_Category_Id",
                table: "Bookings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
