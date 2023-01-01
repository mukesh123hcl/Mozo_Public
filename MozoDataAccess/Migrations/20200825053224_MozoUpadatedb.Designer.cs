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
    [Migration("20200825053224_MozoUpadatedb")]
    partial class MozoUpadatedb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<long?>("Country_MasterId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Country_MasterId");

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

                    b.Property<long?>("ServiceTypesId")
                        .HasColumnType("bigint");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypesId");

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

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("City_Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("City_MasterId")
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

                    b.HasIndex("City_MasterId");

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

                    b.Property<long?>("City_MasterId")
                        .HasColumnType("bigint");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<long?>("Geo_CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("Geo_Category_Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("HouseTypeId")
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

                    b.Property<long?>("ServiceTypesId")
                        .HasColumnType("bigint");

                    b.Property<long>("Service_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("ServicesId")
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

                    b.HasIndex("City_MasterId");

                    b.HasIndex("Geo_CategoryId");

                    b.HasIndex("HouseTypeId");

                    b.HasIndex("ServiceTypesId");

                    b.HasIndex("ServicesId");

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

                    b.Property<long?>("City_MasterId")
                        .HasColumnType("bigint");

                    b.Property<long?>("Geo_CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("Geo_Category_Id")
                        .HasColumnType("bigint");

                    b.Property<float>("Gross_Margin")
                        .HasColumnType("real");

                    b.Property<long?>("HouseTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("House_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDatime")
                        .HasColumnType("datetime2");

                    b.Property<float>("S_GST")
                        .HasColumnType("real");

                    b.Property<long?>("ServiceTypesId")
                        .HasColumnType("bigint");

                    b.Property<long>("Service_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("ServicesId")
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

                    b.HasIndex("City_MasterId");

                    b.HasIndex("Geo_CategoryId");

                    b.HasIndex("HouseTypeId");

                    b.HasIndex("ServiceTypesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("Price");
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

                    b.Property<long?>("ServiceTypesId")
                        .HasColumnType("bigint");

                    b.Property<string>("Service_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Service_Type_Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypesId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("MozoModels.Models.City_Master", b =>
                {
                    b.HasOne("MozoModels.Models.Country_Master", "Country_Master")
                        .WithMany()
                        .HasForeignKey("Country_MasterId");
                });

            modelBuilder.Entity("MozoModels.Models.GST_Config", b =>
                {
                    b.HasOne("MozoModels.Models.ServiceTypes", "ServiceTypes")
                        .WithMany()
                        .HasForeignKey("ServiceTypesId");
                });

            modelBuilder.Entity("MozoModels.Models.Geo_Category", b =>
                {
                    b.HasOne("MozoModels.Models.City_Master", "City_Master")
                        .WithMany()
                        .HasForeignKey("City_MasterId");
                });

            modelBuilder.Entity("MozoModels.Models.Packages", b =>
                {
                    b.HasOne("MozoModels.Models.City_Master", "City_Master")
                        .WithMany()
                        .HasForeignKey("City_MasterId");

                    b.HasOne("MozoModels.Models.Geo_Category", "Geo_Category")
                        .WithMany()
                        .HasForeignKey("Geo_CategoryId");

                    b.HasOne("MozoModels.Models.HouseType", "HouseType")
                        .WithMany()
                        .HasForeignKey("HouseTypeId");

                    b.HasOne("MozoModels.Models.ServiceTypes", "ServiceTypes")
                        .WithMany()
                        .HasForeignKey("ServiceTypesId");

                    b.HasOne("MozoModels.Models.Services", "Services")
                        .WithMany()
                        .HasForeignKey("ServicesId");
                });

            modelBuilder.Entity("MozoModels.Models.Price", b =>
                {
                    b.HasOne("MozoModels.Models.City_Master", "City_Master")
                        .WithMany()
                        .HasForeignKey("City_MasterId");

                    b.HasOne("MozoModels.Models.Geo_Category", "Geo_Category")
                        .WithMany()
                        .HasForeignKey("Geo_CategoryId");

                    b.HasOne("MozoModels.Models.HouseType", "HouseType")
                        .WithMany()
                        .HasForeignKey("HouseTypeId");

                    b.HasOne("MozoModels.Models.ServiceTypes", "ServiceTypes")
                        .WithMany()
                        .HasForeignKey("ServiceTypesId");

                    b.HasOne("MozoModels.Models.Services", "Services")
                        .WithMany()
                        .HasForeignKey("ServicesId");
                });

            modelBuilder.Entity("MozoModels.Models.Services", b =>
                {
                    b.HasOne("MozoModels.Models.ServiceTypes", "ServiceTypes")
                        .WithMany()
                        .HasForeignKey("ServiceTypesId");
                });
#pragma warning restore 612, 618
        }
    }
}