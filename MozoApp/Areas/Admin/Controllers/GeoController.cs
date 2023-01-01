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
	public class GeoController : Controller
	{
		private Mozo_Data_Context context;


		private IServiceRepository<City_Master> repocity;
		private IServiceRepository<Country_Master> repocountry;
		private IServiceRepository<Geo_Category> repogeo;
		private readonly ILogger<CityController> _logger;

		public GeoController(IServiceRepository<City_Master> repocity, IServiceRepository<Geo_Category> repogeo, IServiceRepository<Country_Master> repocountry, ILogger<CityController> logger, Mozo_Data_Context context)
		{
			this.repocity = repocity;
			this.repocountry = repocountry;
			this.repogeo = repogeo;
			_logger = logger;
			this.context = context;
		}

		public IActionResult Index()
		{
			List<Geo_Category_View> model = new List<Geo_Category_View>();
			repogeo.GetAll().ToList().ForEach(b => {
				Geo_Category_View Geo = new Geo_Category_View
				{
					Id = b.Id,
					 Geo_Cateogry= b.Geo_Category_Name,
				
					AddDateTime = b.AddDateTime,
					ModifiedBy = b.ModifiedBy,

				};
				City_Master city = repocity.Get(b.City_Id);
				Geo.City_Name = city.City_Name;
				Country_Master country = repocountry.Get(city.Country_Id);

				Geo.Country_Name = country.Country_Name;
				model.Add(Geo);
			});
			return View("Index", model);
		}

		[HttpGet]
		public IActionResult AddGeo()
		{
			Geo_Category_View model = new Geo_Category_View();
			model.Country = repocountry.GetAll().Select(a => new SelectListItem
			{
				Text = a.Country_Name,
				Value = a.Id.ToString()
			}).ToList();

			
			return PartialView("AddGeo", model);
		}

		[HttpPost]
		public ActionResult AddGeo(Geo_Category_View model)
		{
			if (ModelState.IsValid)
			{
				Geo_Category Temp = context.Set<Geo_Category>().SingleOrDefault(c => (c.City_Id == model.CityId) && (c.Geo_Category_Name == model.Geo_Cateogry));
				if (Temp == null)
				{
					int temp = Convert.ToInt32(HttpContext.Request.Form["CityId"].ToString());
					Geo_Category geo = new Geo_Category
					{
						City_Id = Convert.ToInt32(HttpContext.Request.Form["CityId"].ToString()),
						Geo_Category_Name = model.Geo_Cateogry,
						
						AddDateTime = DateTime.Now,
						ModifiedDatime = DateTime.Now,
						AddedBy = "Admin",



					};
					repogeo.Insert(geo);
					return RedirectToAction("Index");
				}
				else
				{
					model.Country = repocountry.GetAll().Select(a => new SelectListItem
					{
						Text = a.Country_Name,
						Value = a.Id.ToString()
					}).ToList();
					
					return PartialView("AddGeo", model);
				}
			}
			else
			{
				model.Country = repocountry.GetAll().Select(a => new SelectListItem
				{
					Text = a.Country_Name,
					Value = a.Id.ToString()
				}).ToList();
				ModelState.AddModelError(string.Empty, "Geo Already Exists");
				return PartialView("AddGeo", model);
			}

		}

		//[HttpGet]
		//public PartialViewResult EditGeo(long id)
		//{
		//	Geo_Category_View model = new Geo_Category_View();
		//	model.Country = repocountry.GetAll().Select(a => new SelectListItem
		//	{
		//		Text = a.Country_Name,
		//		Value = a.Id.ToString()
		//	}).ToList();
		//	model.City = repocity.Get(model.CountryId).Select(a => new SelectListItem
		//	{
		//		Text = ,
		//		Value = a.Id.ToString()
		//	}).ToList();
		//	Geo_Category Geo = repogeo.Get(id);
		//	if (Geo != null)
		//	{
		//		model.CityId = Geo.City_Id;

				
		//	}
		//	return PartialView("EditCity", model);
		//}

		[HttpPost]
		public ActionResult EditGeo(long id, Geo_Category_View model)
		{
			if (ModelState.IsValid)
			{
				Geo_Category geo = repogeo.Get(id);

				if (geo != null)
				{
					geo.City_Id = model.CityId;

					geo.Geo_Category_Name = model.Geo_Cateogry;
					geo.ModifiedBy = "Admin";
					geo.ModifiedDatime = DateTime.Now;
					repogeo.Update(geo);
				}
				return RedirectToAction("Index");
			}

			ModelState.AddModelError(string.Empty, "There is some error");
			return PartialView("EditCountry", model);
		}

		public IEnumerable<City_Master> GetCity(int countryid)
		{
			
			var City = repocity.GetAll().ToList();

			return City.Where(s=>s.Country_Id==countryid);

		}
		
		public JsonResult GetCityList(int CountryId)
		{
			var City = repocity.GetAll().ToList();
			var citylist = City.Where(s => s.Country_Id == CountryId).Select(m => new SelectListItem()
			{
				Text = m.City_Name.ToString(),
				Value = m.Id.ToString(),
			});
			// ------- Inserting Select Item in List -------

			return Json(citylist);
		}
	}
}
