using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class Mozo_Service_Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Service_Id",
                table: "Packages",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ServicesId",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ServicesId",
                table: "Packages",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Services_ServicesId",
                table: "Packages",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Services_ServicesId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ServicesId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Service_Id",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Packages");
        }
    }
}
