﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MozoDataAccess.Data;

namespace MozoDataAccess.Migrations
{
    [DbContext(typeof(Mozo_Data_Context))]
    [Migration("20201125050738_Update_database Service_Booked")]
    partial class Update_databaseService_Booked
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MozoModels.Models.Area", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("City_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("GeoCategory_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("MozoModels.Models.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("City_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Coupen_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("House_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Requested_Date_time")
                        .HasColumnType("datetime2");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Services")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("User_Id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("MozoModels.Models.Booking_Price", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Booking_Id")
                        .HasColumnType("bigint");

                    b.Property<float>("C_GST")
                        .HasColumnType("real");

                    b.Property<float>("Gross_Margin")
                        .HasColumnType("real");

                    b.Property<float>("Initial_Price")
                        .HasColumnType("real");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<float>("S_GST")
                        .HasColumnType("real");

                    b.Property<float>("Sourge")
                        .HasColumnType("real");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<float>("ToalGST")
                        .HasColumnType("real");

                    b.Property<long>("TotalTime_Required")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalTime_Taken")
                        .HasColumnType("bigint");

                    b.Property<float>("Total_COGS")
                        .HasColumnType("real");

                    b.Property<float>("Total_Revenue")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Booking_Prices");
                });

            modelBuilder.Entity("MozoModels.Models.City_Master", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Country_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("City_Master");
                });

            modelBuilder.Entity("MozoModels.Models.Country_Master", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Country_Master");
                });

            modelBuilder.Entity("MozoModels.Models.Discount_Coupen", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coupen_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coupen_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Discount")
                        .HasColumnType("bigint");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Discount_Coupen");
                });

            modelBuilder.Entity("MozoModels.Models.GST_Config", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C_GST")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<string>("S_GST")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("GST_Config");
                });

            modelBuilder.Entity("MozoModels.Models.Geo_Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("City_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Geo_Category_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Geo_Category");
                });

            modelBuilder.Entity("MozoModels.Models.HouseType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseType_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("HouseTypes");
                });

            modelBuilder.Entity("MozoModels.Models.Packages", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("City_Id")
                        .HasColumnType("bigint");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<long>("Geo_Category_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("House_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Package_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<long>("Service_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<float>("Sourge")
                        .HasColumnType("real");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<float>("Total_Cost")
                        .HasColumnType("real");

                    b.Property<float>("Total_Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("MozoModels.Models.Price", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Avg_Per_Day_Cost")
                        .HasColumnType("real");

                    b.Property<float>("Avg_Per_Day_Price")
                        .HasColumnType("real");

                    b.Property<float>("Avg_Per_Minute_Cost")
                        .HasColumnType("real");

                    b.Property<float>("Avg_Per_Minute_Price")
                        .HasColumnType("real");

                    b.Property<float>("Avg_Per_Month_Cost")
                        .HasColumnType("real");

                    b.Property<float>("Avg_Per_Month_Price")
                        .HasColumnType("real");

                    b.Property<long>("Avg_Time")
                        .HasColumnType("bigint");

                    b.Property<float>("C_GST")
                        .HasColumnType("real");

                    b.Property<long>("City_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Geo_Category_Id")
                        .HasColumnType("bigint");

                    b.Property<float>("Gross_Margin")
                        .HasColumnType("real");

                    b.Property<long>("House_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<long>("No_Of_Person")
                        .HasColumnType("bigint");

                    b.Property<float>("S_GST")
                        .HasColumnType("real");

                    b.Property<long>("Service_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<float>("Sourge")
                        .HasColumnType("real");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<float>("ToalGST")
                        .HasColumnType("real");

                    b.Property<float>("Total_COGS")
                        .HasColumnType("real");

                    b.Property<float>("Total_Revenue")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("MozoModels.Models.ServiceBooked", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Booking_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Booking_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("House_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<long>("Service_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ServiceBooked");
                });

            modelBuilder.Entity("MozoModels.Models.ServiceTypes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Service_Type_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("MozoModels.Models.Services", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Service_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("MozoModels.Models.Sourge_Config", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Surge_Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surge_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sourge_Config");
                });
#pragma warning restore 612, 618
        }
    }
}
