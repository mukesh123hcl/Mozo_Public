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
	public class CityController : Controller
	{
		private Mozo_Data_Context context;


		private IServiceRepository<City_Master> repocity;
		private IServiceRepository<Country_Master> repocountry;
		private readonly ILogger<CityController> _logger;


		public CityController(IServiceRepository<City_Master> repocity, IServiceRepository<Country_Master> repocountry, ILogger<CityController> logger, Mozo_Data_Context context)
		{
			this.repocity = repocity;
			this.repocountry = repocountry;
			_logger = logger;
			this.context = context;
		}

		public IActionResult Index()
		{
			List<City_View_Model> model = new List<City_View_Model>();
			repocity.GetAll().ToList().ForEach(b => {
				City_View_Model city = new City_View_Model
				{
					Id = b.Id,
					City_Name = b.City_Name,
					AddDateTime = b.AddDateTime,
					ModifiedBy = b.ModifiedBy,

				};
				Country_Master country = repocountry.Get(b.Country_Id);
				city.Country_Name = country.Country_Name;
				model.Add(city);
			});
			return View("Index", model);
		}

		[HttpGet]
		public IActionResult AddCity()
		{
			City_View_Model model = new City_View_Model();
			model.Country = repocountry.GetAll().Select(a => new SelectListItem
			{
				Text = a.Country_Name,
				Value = a.Id.ToString()
			}).ToList();
			return PartialView("AddCity", model);
		}

		[HttpPost]
		public ActionResult AddCity(City_View_Model model)
		{
			if (ModelState.IsValid)
			{
				City_Master Temp = context.Set<City_Master>().SingleOrDefault(c => (c.City_Name == model.City_Name) && (c.Country_Id==model.CountryId));
				if (Temp == null)
				{
					City_Master city = new City_Master
					{
						Country_Id = model.CountryId,
						City_Name = model.City_Name,
						AddDateTime = DateTime.Now,
						ModifiedDatime=DateTime.Now,
						AddedBy = "Admin",



					};
					repocity.Insert(city);
					return RedirectToAction("Index");
				}
				else
				{
					model.Country = repocountry.GetAll().Select(a => new SelectListItem
					{
						Text = a.Country_Name,
						Value = a.Id.ToString()
					}).ToList();
					ModelState.AddModelError(string.Empty, "City Already Exists");
					return PartialView("AddCity", model);
				}
			}
			else
			{
				model.Country = repocountry.GetAll().Select(a => new SelectListItem
				{
					Text = a.Country_Name,
					Value = a.Id.ToString()
				}).ToList();
				ModelState.AddModelError(string.Empty, "There is some error");
				return PartialView("AddCity", model);
			}

		}

		[HttpGet]
		public PartialViewResult EditCity(long id)
		{
			City_View_Model model = new City_View_Model();
			model.Country = repocountry.GetAll().Select(a => new SelectListItem
			{
				Text = a.Country_Name,
				Value = a.Id.ToString()
			}).ToList();
			City_Master city = repocity.Get(id);
			if (city != null)
			{
				model.City_Name = city.City_Name;

				model.CountryId = city.Country_Id;
			}
			return PartialView("EditCity", model);
		}

		[HttpPost]
		public ActionResult EditCity(long id, City_View_Model model)
		{
			if (ModelState.IsValid)
			{
				City_Master city = repocity.Get(id);

				if (city != null)
				{
					city.Country_Id = model.CountryId;
					city.City_Name = model.City_Name;
					city.ModifiedBy = "Admin";
					city.ModifiedDatime = DateTime.Now;
					repocity.Update(city);
				}
				return RedirectToAction("Index");
			}

			ModelState.AddModelError(string.Empty, "There is some error");
			return PartialView("EditCountry", model);
		}

		[HttpGet]
		public PartialViewResult DeleteCity(long id)
		{
			City_View_Model model = new City_View_Model();
			model.Country = repocountry.GetAll().Select(a => new SelectListItem
			{
				Text = a.Country_Name,
				Value = a.Id.ToString()
			}).ToList();
			City_Master city = repocity.Get(id);
			if (city != null)
			{
				model.City_Name = city.City_Name;

				model.CountryId = city.Country_Id;
			}
			return PartialView("DeleteCity", model);
		}

		[HttpPost]
		public ActionResult DeleteCity(long id, City_Master form)
		{
			City_Master city = repocity.Get(id);
			if (city != null)
			{
				repocity.Delete(city);
			}
			return RedirectToAction("Index");
		}
	}
}
