using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class RemoveColumnBookingId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Booking_Id",
                table: "ServiceBooked");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Booking_Id",
                table: "ServiceBooked",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
