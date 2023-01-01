using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MozoApp.Areas.Admin.Models;
using MozoDataAccess.Data;
using MozoDataAccess.Repository;
using MozoModels.Models;

namespace MozoApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PriceController : Controller
	{
		private Mozo_Data_Context context;


		private IServiceRepository<City_Master> repocity;
		private IServiceRepository<ServiceTypes> reposervicetypes;
		private IServiceRepository<Geo_Category> repogeo;
		private IServiceRepository<HouseType> repohousetype;
		private IServiceRepository<Price> repoprice;
		private IServiceRepository<GST_Config> repogstconfig;
		private IServiceRepository<Services> reposervices;
		private readonly ILogger<PriceController> _logger;

		public PriceController(IServiceRepository<City_Master> repocity, 
			IServiceRepository<ServiceTypes> reposervicetypes, 
			IServiceRepository<Geo_Category> repogeo, 
			IServiceRepository<HouseType> repohousetype,
			IServiceRepository<Price> repoprice,
			IServiceRepository<GST_Config> repogstconfig,
			IServiceRepository<Services> reposervices,
			ILogger<PriceController> logger, Mozo_Data_Context context)
		{
			this.repocity = repocity;
			this.reposervicetypes = reposervicetypes;
			this.repogeo = repogeo;
			this.repohousetype = repohousetype;
			this.repoprice = repoprice;
			this.repogstconfig = repogstconfig;
			this.reposervices = reposervices;
			_logger = logger;
			this.context = context;
		}




		public IActionResult Index()
		{
			List<Price_View> model = new List<Price_View>();
			repoprice.GetAll().ToList().ForEach(b => {
				Price_View price = new Price_View
				{
					Id = b.Id,
					Avg_Per_Month_Price = b.Avg_Per_Month_Price,
					Gross_Margin=b.Gross_Margin,
					Avg_Time =b.Avg_Time,
					
					AddDateTime = b.AddDateTime,
					ModifiedBy = b.ModifiedBy,

				};
				ServiceTypes serviceTypes = reposervicetypes.Get(b.Service_Type_Id);
				price.Service_Type_Name  = serviceTypes.Service_Type_Name;
				HouseType house = repohousetype.Get(b.House_Type_Id);
				price.House_Type_Name = house.HouseType_Name;
				City_Master city_Master = repocity.Get(b.City_Id);
				price.City_Name = city_Master.City_Name;
				Geo_Category geo_Category = repogeo.Get(b.Geo_Category_Id);
				price.Geo_Category_Name = geo_Category.Geo_Category_Name;
				Services services = reposervices.Get(b.Service_Id);
				price.Service_Name = services.Service_Name;
				model.Add(price);
			});
			return View("Index", model);
		}

		[HttpGet]
		public IActionResult AddPrice()
		{
			Price_View model = new Price_View();
			model.City = repocity.GetAll().Select(a => new SelectListItem
			{
				Text = a.City_Name,
				Value = a.Id.ToString()
			}).ToList();

			model.House_Type = repohousetype.GetAll().Select(a => new SelectListItem
			{
				Text = a.HouseType_Name,
				Value = a.Id.ToString()
			}).ToList();
			model.Serive_Type = reposervicetypes.GetAll().Select(a => new SelectListItem
			{
				Text = a.Service_Type_Name,
				Value = a.Id.ToString()
			}).ToList();

			return PartialView("AddPrice", model);
		}


		[HttpPost]
		public ActionResult AddPrice(Price_View model)
		{
			if (ModelState.IsValid)
			{

				var GST = repogstconfig.GetAll();

				Price price = new Price
				{

					City_Id = model.City_Id,

					Geo_Category_Id = Convert.ToInt32(HttpContext.Request.Form["GeoId"].ToString()),
					Service_Type_Id = model.Service_Type_Id,
					Service_Id = Convert.ToInt32(HttpContext.Request.Form["ServiceId"].ToString()),
					House_Type_Id = model.House_Type_Id,
					Avg_Time = model.Avg_Time,
					Avg_Per_Month_Price = model.Avg_Per_Month_Price,
					Gross_Margin = model.Gross_Margin,
					Avg_Per_Day_Price = (model.Avg_Per_Month_Price / 30),
					Avg_Per_Minute_Price = ((model.Avg_Per_Month_Price / 30)/model.Avg_Time),
						AddDateTime = DateTime.Now,
						ModifiedDatime = DateTime.Now,
						AddedBy = "Admin",



					};
					repoprice.Insert(price);
					return RedirectToAction("Index");
				}
				else
				{
				model.City = repocity.GetAll().Select(a => new SelectListItem
				{
					Text = a.City_Name,
					Value = a.Id.ToString()
				}).ToList();

				model.House_Type = repohousetype.GetAll().Select(a => new SelectListItem
				{
					Text = a.HouseType_Name,
					Value = a.Id.ToString()
				}).ToList();
				model.Serive_Type = reposervicetypes.GetAll().Select(a => new SelectListItem
				{
					Text = a.Service_Type_Name,
					Value = a.Id.ToString()
				}).ToList();


				return PartialView("AddPrice", model);
				}
			
			
				
			}

		
		public JsonResult GetGeoList(int city_id)
		{
			var Geo = repogeo.GetAll().ToList();
			var geolist = Geo.Where(s => s.City_Id == city_id).Select(m => new SelectListItem()
			{
				Text = m.Geo_Category_Name.ToString(),
				Value = m.Id.ToString(),
			});
			// ------- Inserting Select Item in List -------

			return Json(geolist);
		}

		public JsonResult GetService_list(int service_type_Id)
		 {
			var Service = reposervices.GetAll().ToList();
			var servicelist = Service.Where(s => s.Service_Type_Id == service_type_Id).Select(m => new SelectListItem()
			{
				Text = m.Service_Name.ToString(),
				Value = m.Id.ToString(),
			});
			// ------- Inserting Select Item in List -------

			return Json(servicelist);
		}
	}
}
