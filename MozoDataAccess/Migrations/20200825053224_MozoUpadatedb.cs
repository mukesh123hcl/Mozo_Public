using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class MozoUpadatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total_Cost",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Total_Price",
                table: "Price");

            migrationBuilder.AddColumn<float>(
                name: "C_GST",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Gross_Margin",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "S_GST",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ToalGST",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total_COGS",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total_Revenue",
                table: "Price",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Geo_Category",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GST_Config",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    S_GST = table.Column<string>(nullable: false),
                    C_GST = table.Column<string>(nullable: false),
                    Service_Type_Id = table.Column<long>(nullable: false),
                    ServiceTypesId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GST_Config", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GST_Config_ServiceTypes_ServiceTypesId",
                        column: x => x.ServiceTypesId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GST_Config_ServiceTypesId",
                table: "GST_Config",
                column: "ServiceTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GST_Config");

            migrationBuilder.DropColumn(
                name: "C_GST",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Gross_Margin",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "S_GST",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "ToalGST",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Total_COGS",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Total_Revenue",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Geo_Category");

            migrationBuilder.AddColumn<float>(
                name: "Total_Cost",
                table: "Price",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total_Price",
                table: "Price",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
