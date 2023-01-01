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
	public class HousetypeController : Controller
	{
		private Mozo_Data_Context context;


		private IServiceRepository<HouseType> repohousetype;
		private readonly ILogger<HousetypeController> _logger;


		public HousetypeController(IServiceRepository<HouseType> repohousetype, ILogger<HousetypeController> logger, Mozo_Data_Context context)
		{
			this.repohousetype = repohousetype;
			_logger = logger;
			this.context = context;
		}
		public IActionResult Index()
		{
			List<HouseType> model = new List<HouseType>();
			repohousetype.GetAll().ToList().ForEach(a => {
				HouseType housetype = new HouseType
				{
					Id = a.Id,
					HouseType_Name = a.HouseType_Name,
					AddDateTime = a.AddDateTime,
					ModifiedDatime = a.ModifiedDatime
				};

				model.Add(housetype);
			});
			return View("Index", model);
		}

		[HttpGet]
		public IActionResult AddHousetype()
		{
			HouseType model = new HouseType();
			return PartialView("AddHousetype", model);
		}

		[HttpPost]
		public ActionResult AddHousetype(HouseType model)
		{
			if (ModelState.IsValid)
			{
				HouseType Temp = context.Set<HouseType>().SingleOrDefault(c => c.HouseType_Name == model.HouseType_Name);
				if (Temp == null)
				{
					HouseType houseType = new HouseType
					{
						HouseType_Name = model.HouseType_Name,
						AddDateTime = DateTime.Now,
						AddedBy = "Admin",



					};
					repohousetype.Insert(houseType);
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "House Type Already Exists");
					return PartialView("AddHousetype", model);
				}
			}
			else
			{
				ModelState.AddModelError(string.Empty, "There is some error");
				return PartialView("AddHousetype", model);
			}

		}

		[HttpGet]
		public IActionResult EditHousetype(long id)
		{
			HouseType model = new HouseType();

			HouseType houseType = repohousetype.Get(id);
			if (houseType != null)
			{
				model.HouseType_Name = houseType.HouseType_Name;


			}
			return PartialView("EditHousetype", model);
		}

		[HttpPost]
		public ActionResult EditHousetype(long id, HouseType model)
		{
			if (ModelState.IsValid)
			{
				HouseType houseType = repohousetype.Get(id);

				if (houseType != null)
				{
					houseType.HouseType_Name = model.HouseType_Name;
					houseType.ModifiedBy = "Admin";
					houseType.ModifiedDatime = DateTime.Now;
					repohousetype.Update(houseType);
				}
				return RedirectToAction("Index");
			}

			ModelState.AddModelError(string.Empty, "There is some error");
			return PartialView("EditHousetype", model);
		}

		[HttpGet]
		public PartialViewResult DeleteHousetype(long id)
		{
			HouseType model = new HouseType();
			HouseType houseType = repohousetype.Get(id);
			if (houseType != null)
			{
				model.HouseType_Name = houseType.HouseType_Name;


			}
			return PartialView("DeleteHousetype", model);
		}
		[HttpPost]
		public ActionResult DeleteHousetype(long id, HouseType form)
		{
			HouseType houseType = repohousetype.Get(id);
			if (houseType != null)
			{
				repohousetype.Delete(houseType);
			}
			return RedirectToAction("Index");
		}
	}
}
