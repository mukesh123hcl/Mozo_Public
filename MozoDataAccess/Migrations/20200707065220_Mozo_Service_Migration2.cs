using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class Mozo_Service_Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_HouseTypes_HouseType_ID",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_ServiceTypes_Service_Type_Id",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Price_Packages_Package_Id",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_Service_Type_Id",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_Service_Type_Id",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Price_Package_Id",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Packages_HouseType_ID",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_Service_Type_Id",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ServiceType_Id",
                table: "Services");

            migrationBuilder.AddColumn<long>(
                name: "ServiceTypesId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PackagesId",
                table: "Price",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HouseTypeId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceTypesId",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypesId",
                table: "Services",
                column: "ServiceTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_PackagesId",
                table: "Price",
                column: "PackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_HouseTypeId",
                table: "Packages",
                column: "HouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ServiceTypesId",
                table: "Packages",
                column: "ServiceTypesId");

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
                name: "FK_Price_Packages_PackagesId",
                table: "Price",
                column: "PackagesId",
                principalTable: "Packages",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_HouseTypes_HouseTypeId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_ServiceTypes_ServiceTypesId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Price_Packages_PackagesId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypesId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceTypesId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Price_PackagesId",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Packages_HouseTypeId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ServiceTypesId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ServiceTypesId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PackagesId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "HouseTypeId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ServiceTypesId",
                table: "Packages");

            migrationBuilder.AddColumn<long>(
                name: "ServiceType_Id",
                table: "Services",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Services_Service_Type_Id",
                table: "Services",
                column: "Service_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Price_Package_Id",
                table: "Price",
                column: "Package_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_HouseType_ID",
                table: "Packages",
                column: "HouseType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Service_Type_Id",
                table: "Packages",
                column: "Service_Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_HouseTypes_HouseType_ID",
                table: "Packages",
                column: "HouseType_ID",
                principalTable: "HouseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_ServiceTypes_Service_Type_Id",
                table: "Packages",
                column: "Service_Type_Id",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Packages_Package_Id",
                table: "Price",
                column: "Package_Id",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_Service_Type_Id",
                table: "Services",
                column: "Service_Type_Id",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
