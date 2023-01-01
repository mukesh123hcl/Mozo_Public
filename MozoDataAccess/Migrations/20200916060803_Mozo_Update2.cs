using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class Mozo_Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Master_Country_Master_Country_MasterId",
                table: "City_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_Geo_Category_City_Master_City_MasterId",
                table: "Geo_Category");

            migrationBuilder.DropForeignKey(
                name: "FK_GST_Config_ServiceTypes_ServiceTypesId",
                table: "GST_Config");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_City_Master_City_MasterId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Geo_Category_Geo_CategoryId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_HouseTypes_HouseTypeId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_ServiceTypes_ServiceTypesId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Services_ServicesId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypesId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceTypesId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Packages_City_MasterId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_Geo_CategoryId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_HouseTypeId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ServiceTypesId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ServicesId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_GST_Config_ServiceTypesId",
                table: "GST_Config");

            migrationBuilder.DropIndex(
                name: "IX_Geo_Category_City_MasterId",
                table: "Geo_Category");

            migrationBuilder.DropIndex(
                name: "IX_City_Master_Country_MasterId",
                table: "City_Master");

            migrationBuilder.DropColumn(
                name: "ServiceTypesId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "City_MasterId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Geo_CategoryId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "HouseTypeId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ServiceTypesId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ServiceTypesId",
                table: "GST_Config");

            migrationBuilder.DropColumn(
                name: "City_MasterId",
                table: "Geo_Category");

            migrationBuilder.DropColumn(
                name: "Country_MasterId",
                table: "City_Master");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ServiceTypesId",
                table: "Services",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "City_MasterId",
                table: "Packages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Geo_CategoryId",
                table: "Packages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HouseTypeId",
                table: "Packages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceTypesId",
                table: "Packages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServicesId",
                table: "Packages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceTypesId",
                table: "GST_Config",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "City_MasterId",
                table: "Geo_Category",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Country_MasterId",
                table: "City_Master",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypesId",
                table: "Services",
                column: "ServiceTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_City_MasterId",
                table: "Packages",
                column: "City_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Geo_CategoryId",
                table: "Packages",
                column: "Geo_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_HouseTypeId",
                table: "Packages",
                column: "HouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ServiceTypesId",
                table: "Packages",
                column: "ServiceTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ServicesId",
                table: "Packages",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_GST_Config_ServiceTypesId",
                table: "GST_Config",
                column: "ServiceTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Geo_Category_City_MasterId",
                table: "Geo_Category",
                column: "City_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_City_Master_Country_MasterId",
                table: "City_Master",
                column: "Country_MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Master_Country_Master_Country_MasterId",
                table: "City_Master",
                column: "Country_MasterId",
                principalTable: "Country_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Geo_Category_City_Master_City_MasterId",
                table: "Geo_Category",
                column: "City_MasterId",
                principalTable: "City_Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GST_Config_ServiceTypes_ServiceTypesId",
                table: "GST_Config",
                column: "ServiceTypesId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Packages_HouseTypes_HouseTypeId",
                table: "Packages",
                column: "HouseTypeId",
                principalTable: "HouseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_ServiceTypes_ServiceTypesId",
                table: "Packages",
                column: "ServiceTypesId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Services_ServicesId",
                table: "Packages",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypesId",
                table: "Services",
                column: "ServiceTypesId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
