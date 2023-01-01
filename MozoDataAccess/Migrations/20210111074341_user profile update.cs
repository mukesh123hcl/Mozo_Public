using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MozoDataAccess.Migrations
{
    public partial class userprofileupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Serivice_User_Skill",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    service_type_id = table.Column<long>(nullable: false),
                    service_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serivice_User_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service_personal_info",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    user_title = table.Column<string>(nullable: true),
                    first_name = table.Column<string>(nullable: true),
                    middle_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    religion = table.Column<string>(nullable: true),
                    dob = table.Column<DateTime>(nullable: false),
                    age = table.Column<string>(nullable: true),
                    maritial_status = table.Column<string>(nullable: true),
                    marriage_date = table.Column<DateTime>(nullable: false),
                    profile_photo = table.Column<string>(nullable: true),
                    about = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_personal_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service_User_Bank_Detail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    bank_name = table.Column<string>(nullable: true),
                    ifsc_code = table.Column<string>(nullable: true),
                    account_name = table.Column<string>(nullable: true),
                    account_number = table.Column<long>(nullable: false),
                    upi_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_User_Bank_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service_User_Exp_Edu",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    experience = table.Column<string>(nullable: true),
                    certified = table.Column<bool>(nullable: false),
                    cerified_institute = table.Column<string>(nullable: true),
                    certificate_no = table.Column<string>(nullable: true),
                    certified_year = table.Column<string>(nullable: true),
                    edu_qalif = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_User_Exp_Edu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_compliment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    compliment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_compliment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Contact_Details",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    address_id = table.Column<long>(nullable: false),
                    contry_code = table.Column<string>(nullable: true),
                    primery_contact_number = table.Column<string>(nullable: true),
                    secondry_contact_number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Contact_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Identification",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    add_doc_type = table.Column<string>(nullable: true),
                    add_doc_no = table.Column<string>(nullable: true),
                    add_doc = table.Column<string>(nullable: true),
                    id_doc_type = table.Column<string>(nullable: true),
                    id_doc_no = table.Column<string>(nullable: true),
                    id_doc = table.Column<string>(nullable: true),
                    pan_card_no = table.Column<string>(nullable: true),
                    pan_card = table.Column<string>(nullable: true),
                    dl_no = table.Column<string>(nullable: true),
                    dl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Identification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Lang_Know",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    lang_known = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Lang_Know", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Reating",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDatime = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    booking_id = table.Column<long>(nullable: false),
                    rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Reating", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serivice_User_Skill");

            migrationBuilder.DropTable(
                name: "Service_personal_info");

            migrationBuilder.DropTable(
                name: "Service_User_Bank_Detail");

            migrationBuilder.DropTable(
                name: "Service_User_Exp_Edu");

            migrationBuilder.DropTable(
                name: "User_compliment");

            migrationBuilder.DropTable(
                name: "User_Contact_Details");

            migrationBuilder.DropTable(
                name: "User_Identification");

            migrationBuilder.DropTable(
                name: "User_Lang_Know");

            migrationBuilder.DropTable(
                name: "User_Reating");
        }
    }
}
