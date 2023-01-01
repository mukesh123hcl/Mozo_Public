using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class Mozo_Service_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    HouseType_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Service_Type_Id = table.Column<long>(nullable: false),
                    Service_Type_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Package_Name = table.Column<string>(nullable: false),
                    Service_Type_Id = table.Column<long>(nullable: false),
                    HouseType_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_HouseTypes_HouseType_ID",
                        column: x => x.HouseType_ID,
                        principalTable: "HouseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_ServiceTypes_Service_Type_Id",
                        column: x => x.Service_Type_Id,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    ServiceType_Id = table.Column<long>(nullable: false),
                    Service_Name = table.Column<string>(nullable: false),
                    Service_Type_Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ServiceTypes_Service_Type_Id",
                        column: x => x.Service_Type_Id,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Actual_Price = table.Column<float>(nullable: false),
                    Price_Type = table.Column<string>(nullable: false),
                    Total_Price = table.Column<float>(nullable: false),
                    Package_Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_Packages_Package_Id",
                        column: x => x.Package_Id,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_HouseType_ID",
                table: "Packages",
                column: "HouseType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Service_Type_Id",
                table: "Packages",
                column: "Service_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Price_Package_Id",
                table: "Price",
                column: "Package_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Service_Type_Id",
                table: "Services",
                column: "Service_Type_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "HouseTypes");

            migrationBuilder.DropTable(
                name: "ServiceTypes");
        }
    }
}
