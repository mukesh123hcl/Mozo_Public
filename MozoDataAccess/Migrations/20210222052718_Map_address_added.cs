using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class Map_address_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "User_Location",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "User_Location",
                newName: "latitude");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "User_Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "map_address",
                table: "User_Location",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city",
                table: "User_Location");

            migrationBuilder.DropColumn(
                name: "map_address",
                table: "User_Location");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "User_Location",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "User_Location",
                newName: "Latitude");
        }
    }
}
