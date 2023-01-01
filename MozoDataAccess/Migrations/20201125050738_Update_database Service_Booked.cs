using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class Update_databaseService_Booked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Booking_Type",
                table: "ServiceBooked",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "House_Type_Id",
                table: "ServiceBooked",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Booking_Type",
                table: "ServiceBooked");

            migrationBuilder.DropColumn(
                name: "House_Type_Id",
                table: "ServiceBooked");
        }
    }
}
