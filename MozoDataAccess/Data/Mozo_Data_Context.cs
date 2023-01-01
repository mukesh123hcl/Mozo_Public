using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MozoModels.Models;
namespace MozoDataAccess.Data
{
	public class Mozo_Data_Context: DbContext
	{
		public Mozo_Data_Context(DbContextOptions<Mozo_Data_Context> options) : base(options)
			{

		}

		public DbSet<ServiceTypes> ServiceTypes { get; set; }
		public DbSet<Services> Services { get; set; }
		public DbSet<HouseType> HouseTypes { get; set; }
		public DbSet<Packages> Packages { get; set; }
		public DbSet<Price> Prices { get; set; }

		public DbSet<Country_Master> Country_Masters { get; set; }

		public DbSet<City_Master> City_Masters { get; set; }

		public DbSet<Geo_Category> Geo_Categories { get; set; }
		public DbSet<GST_Config> GST_Configs { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Booking_Price> Booking_Prices { get; set; }

		public DbSet<Sourge_Config> Sourge_Config { get; set; }
		public DbSet<Discount_Coupen> Discount_Coupen { get; set; }
		public DbSet<ServiceBooked> ServiceBookeds { get; set; }
		public DbSet<Area> areas { get; set; }
		public DbSet<Booking_Addresss> booking_AddresssesP { get; set; }
		public DbSet<Serivice_User_Skills> Serivice_User_Skills { get; set; }
		public DbSet<Service_personal_info> service_Personal_Infos { get; set; }
		public DbSet<Service_User_Bank_Details> service_User_Bank_Details { get; set; }
		public DbSet<Service_User_Exp_Edu> service_User_Exp_Edus { get; set; }
		public DbSet<User_compliments> user_Compliments { get; set; }
		public DbSet<User_Contact_Details> User_Contact_Details { get; set; }
		public DbSet<User_Identification> user_Identifications { get; set; }
		public DbSet<User_Lang_Know> user_Lang_Knows { get; set; }
		public DbSet<User_Reating> user_Reatings { get; set; }
		public DbSet<User_Location> user_Locations { get; set; }
		public DbSet<Duty_Status> duty_Status { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ServiceTypes>().ToTable("ServiceTypes");
			modelBuilder.Entity<Services>().ToTable("Services");
			modelBuilder.Entity<HouseType>().ToTable("HouseTypes");
			modelBuilder.Entity<Packages>().ToTable("Packages");
			modelBuilder.Entity<Price>().ToTable("Price");
			modelBuilder.Entity<Country_Master>().ToTable("Country_Master");
			modelBuilder.Entity<City_Master>().ToTable("City_Master");
			modelBuilder.Entity<Geo_Category>().ToTable("Geo_Category");
			modelBuilder.Entity<GST_Config>().ToTable("GST_Config");
			modelBuilder.Entity<Booking>().ToTable("Bookings");
			modelBuilder.Entity<Booking_Price>().ToTable("Booking_Prices");
			modelBuilder.Entity<Sourge_Config>().ToTable("Sourge_Config");
			modelBuilder.Entity<Discount_Coupen>().ToTable("Discount_Coupen");
			modelBuilder.Entity<ServiceBooked>().ToTable("ServiceBooked");
			modelBuilder.Entity<Area>().ToTable("Area");
			modelBuilder.Entity<Booking_Addresss>().ToTable("User_Addresss");
			modelBuilder.Entity<Serivice_User_Skills>().ToTable("Serivice_User_Skill");
			modelBuilder.Entity<Service_personal_info>().ToTable("Service_personal_info");
			modelBuilder.Entity<Service_User_Bank_Details>().ToTable("Service_User_Bank_Detail");
			modelBuilder.Entity<Service_User_Exp_Edu>().ToTable("Service_User_Exp_Edu");
			modelBuilder.Entity<User_compliments>().ToTable("User_compliment");
			modelBuilder.Entity<User_Contact_Details>().ToTable("User_Contact_Details");
			modelBuilder.Entity<User_Identification>().ToTable("User_Identification");
			modelBuilder.Entity<User_Lang_Know>().ToTable("User_Lang_Know");
			modelBuilder.Entity<User_Reating>().ToTable("User_Reating");
			modelBuilder.Entity<User_Location>().ToTable("User_Location");
			modelBuilder.Entity<Duty_Status>().ToTable("Duty_Status");

		}

	}
}
