using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class Update_databaseService_Booked_Add_Address_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking_Addresss",
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
                    AddLine1 = table.Column<string>(nullable: true),
                    AddLine2 = table.Column<string>(nullable: true),
                    AddLine3 = table.Column<string>(nullable: true),
                    Pincode = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    City_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Addresss", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_Addresss");
        }
    }
}
