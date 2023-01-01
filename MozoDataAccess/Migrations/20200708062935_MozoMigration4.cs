using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class MozoMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_Packages_PackagesId",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Price_PackagesId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Actual_Price",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Package_Id",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "PackagesId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Price_Type",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "HouseType_ID",
                table: "Packages");

            migrationBuilder.AddColumn<float>(
                name: "Avg_Per_Day_Cost",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Avg_Per_Day_Price",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Avg_Per_Minute_Cost",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Avg_Per_Minute_Price",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Avg_Per_Month_Cost",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Avg_Per_Month_Price",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<long>(
                name: "Avg_Time",
                table: "Price",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "City_Id",
                table: "Price",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "City_MasterId",
                table: "Price",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Geo_CategoryId",
                table: "Price",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Geo_Category_Id",
                table: "Price",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "HouseTypeId",
                table: "Price",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "House_Type_Id",
                table: "Price",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ServiceTypesId",
                table: "Price",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Service_Id",
                table: "Price",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Service_Type_Id",
                table: "Price",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ServicesId",
                table: "Price",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Sourge",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total_Cost",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<long>(
                name: "City_Id",
                table: "Packages",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "City_MasterId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Cost",
                table: "Packages",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<long>(
                name: "Geo_CategoryId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Geo_Category_Id",
                table: "Packages",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "House_Type_Id",
                table: "Packages",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Packages",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Sourge",
                table: "Packages",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total_Cost",
                table: "Packages",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total_Price",
                table: "Packages",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Country_Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Country_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country_Master", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City_Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    City_Name = table.Column<string>(nullable: false),
                    Country_Id = table.Column<long>(nullable: false),
                    Country_MasterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Master_Country_Master_Country_MasterId",
                        column: x => x.Country_MasterId,
                        principalTable: "Country_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Geo_Category",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Geo_Category_Name = table.Column<string>(nullable: false),
                    City_Id = table.Column<long>(nullable: false),
                    City_MasterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geo_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Geo_Category_City_Master_City_MasterId",
                        column: x => x.City_MasterId,
                        principalTable: "City_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Packages_City_MasterId",
                table: "Packages",
                column: "City_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Geo_CategoryId",
                table: "Packages",
                column: "Geo_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_City_Master_Country_MasterId",
                table: "City_Master",
                column: "Country_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Geo_Category_City_MasterId",
                table: "Geo_Category",
                column: "City_MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_City_Master_City_MasterId",
                table: "Packages",
                column: "City_MasterId",
                principalTable: "City_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Geo_Category_Geo_CategoryId",
                table: "Packages",
                column: "Geo_CategoryId",
                principalTable: "Geo_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_City_Master_City_MasterId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Geo_Category_Geo_CategoryId",
                table: "Packages");

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

            migrationBuilder.DropTable(
                name: "Geo_Category");

            migrationBuilder.DropTable(
                name: "City_Master");

            migrationBuilder.DropTable(
                name: "Country_Master");

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

            migrationBuilder.DropIndex(
                name: "IX_Packages_City_MasterId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_Geo_CategoryId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Avg_Per_Day_Cost",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Avg_Per_Day_Price",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Avg_Per_Minute_Cost",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Avg_Per_Minute_Price",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Avg_Per_Month_Cost",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Avg_Per_Month_Price",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Avg_Time",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "City_Id",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "City_MasterId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Geo_CategoryId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Geo_Category_Id",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "HouseTypeId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "House_Type_Id",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "ServiceTypesId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Service_Id",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Service_Type_Id",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Sourge",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Total_Cost",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "City_Id",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "City_MasterId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Geo_CategoryId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Geo_Category_Id",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "House_Type_Id",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Sourge",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Total_Cost",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Total_Price",
                table: "Packages");

            migrationBuilder.AddColumn<float>(
                name: "Actual_Price",
                table: "Price",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<long>(
                name: "Package_Id",
                table: "Price",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PackagesId",
                table: "Price",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price_Type",
                table: "Price",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "HouseType_ID",
                table: "Packages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Price_PackagesId",
                table: "Price",
                column: "PackagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Packages_PackagesId",
                table: "Price",
                column: "PackagesId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
