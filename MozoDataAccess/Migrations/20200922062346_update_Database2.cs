using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class update_Database2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discount_Coupen",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Coupen_Code = table.Column<string>(nullable: false),
                    Coupen_Type = table.Column<string>(nullable: false),
                    Discount = table.Column<long>(nullable: false),
                    Duration = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_Coupen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sourge_Config",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Surge_type = table.Column<string>(nullable: false),
                    Surge_Price = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sourge_Config", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount_Coupen");

            migrationBuilder.DropTable(
                name: "Sourge_Config");
        }
    }
}
