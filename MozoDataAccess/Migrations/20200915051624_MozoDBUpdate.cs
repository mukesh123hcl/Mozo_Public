using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class MozoDBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_City_Master_City_MasterId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_Price_Geo_Category_Geo_CategoryId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_Price_HouseTypes_HouseTypeId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_Price_ServiceTypes_ServiceTypesId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_Price_Services_ServicesId",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Price_City_MasterId",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Price_Geo_CategoryId",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Price_HouseTypeId",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Price_ServiceTypesId",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Price_ServicesId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "City_MasterId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Geo_CategoryId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "HouseTypeId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "ServiceTypesId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Price");

            migrationBuilder.CreateTable(
                name: "Booking_Prices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Booking_Id = table.Column<long>(nullable: false),
                    TotalTime_Required = table.Column<long>(nullable: false),
                    TotalTime_Taken = table.Column<long>(nullable: false),
                    Sourge = table.Column<float>(nullable: false),
                    ToalGST = table.Column<float>(nullable: false),
                    C_GST = table.Column<float>(nullable: false),
                    S_GST = table.Column<float>(nullable: false),
                    Initial_Price = table.Column<float>(nullable: false),
                    Total_Revenue = table.Column<float>(nullable: false),
                    Gross_Margin = table.Column<float>(nullable: false),
                    Total_COGS = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    City_Id = table.Column<long>(nullable: false),
                    Geo_Category_Id = table.Column<long>(nullable: false),
                    Service_Type_Id = table.Column<long>(nullable: false),
                    Service_Id = table.Column<long>(nullable: false),
                    House_Type_Id = table.Column<long>(nullable: false),
                    Requested_Date_time = table.Column<DateTime>(nullable: false),
                    User_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_Prices");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.AddColumn<long>(
                name: "City_MasterId",
                table: "Price",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Geo_CategoryId",
                table: "Price",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HouseTypeId",
                table: "Price",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceTypesId",
                table: "Price",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServicesId",
                table: "Price",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Price_City_MasterId",
                table: "Price",
                column: "City_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_Geo_CategoryId",
                table: "Price",
                column: "Geo_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_HouseTypeId",
                table: "Price",
                column: "HouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_ServiceTypesId",
                table: "Price",
                column: "ServiceTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_ServicesId",
                table: "Price",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_City_Master_City_MasterId",
                table: "Price",
                column: "City_MasterId",
                principalTable: "City_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Geo_Category_Geo_CategoryId",
                table: "Price",
                column: "Geo_CategoryId",
                principalTable: "Geo_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_HouseTypes_HouseTypeId",
                table: "Price",
                column: "HouseTypeId",
                principalTable: "HouseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_ServiceTypes_ServiceTypesId",
                table: "Price",
                column: "ServiceTypesId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Services_ServicesId",
                table: "Price",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
