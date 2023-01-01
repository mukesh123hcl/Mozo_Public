using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class Update_databaseService_Booked_Modify_Address_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking_Addresss",
                table: "Booking_Addresss");

            migrationBuilder.DropColumn(
                name: "Booking_Id",
                table: "Booking_Addresss");

            migrationBuilder.RenameTable(
                name: "Booking_Addresss",
                newName: "User_Addresss");

            migrationBuilder.AddColumn<long>(
                name: "Address_Id",
                table: "ServiceBooked",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "User_Id",
                table: "User_Addresss",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Addresss",
                table: "User_Addresss",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Addresss",
                table: "User_Addresss");

            migrationBuilder.DropColumn(
                name: "Address_Id",
                table: "ServiceBooked");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "User_Addresss");

            migrationBuilder.RenameTable(
                name: "User_Addresss",
                newName: "Booking_Addresss");

            migrationBuilder.AddColumn<long>(
                name: "Booking_Id",
                table: "Booking_Addresss",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking_Addresss",
                table: "Booking_Addresss",
                column: "Id");
        }
    }
}
