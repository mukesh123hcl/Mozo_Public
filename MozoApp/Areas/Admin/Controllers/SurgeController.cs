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
	public class SurgeController : Controller
	{

		private Mozo_Data_Context context;


		private IServiceRepository<Sourge_Config> reposourge;
		private readonly ILogger<SurgeController> _logger;


		public SurgeController(IServiceRepository<Sourge_Config> reposourge, ILogger<SurgeController> logger, Mozo_Data_Context context)
		{
			this.reposourge = reposourge;
			_logger = logger;
			this.context = context;
		}

		public IActionResult Index()
		{
			List<Sourge_Config> model = new List<Sourge_Config>();
			reposourge.GetAll().ToList().ForEach(a =>
			{
				Sourge_Config sourge_Config = new Sourge_Config
				{
					Id = a.Id,
					Surge_type = a.Surge_type,
					Surge_Price = a.Surge_Price,

					AddDateTime = a.AddDateTime,
					ModifiedBy = a.ModifiedBy

				};

				model.Add(sourge_Config);
			});
			return View("Index", model);
		}

		[HttpGet]
		public IActionResult AddSurge()
		{
			Sourge_Config model = new Sourge_Config();
			return PartialView("AddSurge", model);
		}

		[HttpPost]
		public ActionResult AddSurge(Sourge_Config model)
		{
			if (ModelState.IsValid)
			{
				Sourge_Config Temp = context.Set<Sourge_Config>().SingleOrDefault(c => c.Surge_type == model.Surge_type);
				if (Temp == null)
				{
					Sourge_Config sourge_Config = new Sourge_Config
					{
						Surge_type = model.Surge_type,
						Surge_Price = model.Surge_Price,

						Status = true,
						AddDateTime = DateTime.Now,
						AddedBy = "Admin",



					};
					reposourge.Insert(sourge_Config);
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Coupen Already Exists");
					return PartialView("AddSurge", model);
				}
			}
			else
			{
				ModelState.AddModelError(string.Empty, "There is some error");
				return PartialView("AddSurge", model);
			}

		}

		[HttpGet]
		public IActionResult EditSurge(long id)
		{
			Sourge_Config model = new Sourge_Config();

			Sourge_Config sourge_Config = reposourge.Get(id);
			if (sourge_Config != null)
			{
				model.Surge_type = sourge_Config.Surge_type;
				model.Surge_Price=sourge_Config.Surge_Price;


			}
			return PartialView("EditSourge", model);
		}

		[HttpPost]
		public ActionResult EditSurge(long id, Sourge_Config model)
		{
			if (ModelState.IsValid)
			{
				Sourge_Config sourge_Config = reposourge.Get(id);

				if (sourge_Config != null)
				{
					sourge_Config.Surge_type = model.Surge_type;
					sourge_Config.Surge_Price = model.Surge_Price;

					sourge_Config.ModifiedBy = "Admin";
					sourge_Config.ModifiedDatime = DateTime.Now;
					reposourge.Update(sourge_Config);
				}
				return RedirectToAction("Index");
			}

			ModelState.AddModelError(string.Empty, "There is some error");
			return PartialView("EditSurge", model);
		}
	}
}
