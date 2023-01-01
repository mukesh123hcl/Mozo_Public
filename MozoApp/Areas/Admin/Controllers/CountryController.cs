using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MozoDataAccess.Data;
using MozoDataAccess.Repository;
using MozoModels.Models;

namespace MozoApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CountryController : Controller
	{

		private Mozo_Data_Context context;

	
		private IServiceRepository<Country_Master> repocountry;
		private readonly ILogger<CountryController> _logger;

	
		public CountryController(IServiceRepository<Country_Master> repocountry, ILogger<CountryController> logger, Mozo_Data_Context context)
		{
			this.repocountry = repocountry;
			_logger = logger;
			this.context = context;
		}

		public IActionResult Index()
		{
			List<Country_Master> model = new List<Country_Master>();
			repocountry.GetAll().ToList().ForEach(a => {
				Country_Master country = new Country_Master
				{
					Id = a.Id,
					Country_Name = a.Country_Name,
					AddDateTime = a.AddDateTime
				};
				
				model.Add(country);
			});
			return View("Index", model);
		}

		[HttpGet]
		public IActionResult AddCountry()
		{
			Country_Master model = new Country_Master();
			return PartialView("AddCountry", model);
		}

		[HttpPost]
		public ActionResult AddCountry(Country_Master model)
		{
			if (ModelState.IsValid)
			{
				Country_Master Temp = context.Set<Country_Master>().SingleOrDefault(c => c.Country_Name == model.Country_Name);
				if (Temp == null)
				{
					Country_Master country = new Country_Master
					{
						Country_Name = model.Country_Name,
						AddDateTime = DateTime.Now,
						AddedBy = "Admin",



					};
					repocountry.Insert(country);
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Country Already Exists");
					return PartialView("AddCountry", model);
				}
			}
			else
			{
				ModelState.AddModelError(string.Empty, "There is some error");
				return PartialView("AddCountry", model);
			}

		}

		[HttpGet]
		public IActionResult EditCountry(long id)
		{
			Country_Master model = new Country_Master();
			
			Country_Master country = repocountry.Get(id);
			if (country != null)
			{
				model.Country_Name = country.Country_Name;
	
			
			}
			return PartialView("EditCountry", model);
		}

		[HttpPost]
		public ActionResult EditCountry(long id, Country_Master model)
		{
			if (ModelState.IsValid)
			{
				Country_Master country = repocountry.Get(id);
				
				if (country != null)
				{
					country.Country_Name = model.Country_Name;
					country.ModifiedBy = "Admin";
					country.ModifiedDatime = DateTime.Now;
					repocountry.Update(country);
				}
				return RedirectToAction("Index");
			}

			ModelState.AddModelError(string.Empty, "There is some error");
			return PartialView("EditCountry", model);
		}

		[HttpGet]
		public PartialViewResult DeleteCountry(long id)
		{
			Country_Master model = new Country_Master();
			Country_Master country = repocountry.Get(id);
			if (country != null)
			{
				model.Country_Name = country.Country_Name;


			}
			return PartialView("DeleteCountry", model);
		}
		[HttpPost]
		public ActionResult DeleteCountry(long id, Country_Master form)
		{
			Country_Master country = repocountry.Get(id);
			if (country != null)
			{
				repocountry.Delete(country);
			}
			return RedirectToAction("Index");
		}
	}
}
