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
	public class DiscountController : Controller
	{
		private Mozo_Data_Context context;


		private IServiceRepository<Discount_Coupen> repodiscount;
		private readonly ILogger<DiscountController> _logger;


		public DiscountController(IServiceRepository<Discount_Coupen> repodiscount, ILogger<DiscountController> logger, Mozo_Data_Context context)
		{
			this.repodiscount = repodiscount;
			_logger = logger;
			this.context = context;
		}

		public IActionResult Index()
		{
			List<Discount_Coupen> model = new List<Discount_Coupen>();
			repodiscount.GetAll().ToList().ForEach(a => {
				Discount_Coupen discount_Coupen = new Discount_Coupen
				{
					Id = a.Id,
					Coupen_Code = a.Coupen_Code,
					Coupen_Type=a.Coupen_Type,
					Duration=a.Duration,
					Discount=a.Discount,
					AddDateTime = a.AddDateTime,
					ModifiedBy=a.ModifiedBy
					
				};

				model.Add(discount_Coupen);
			});
			return View("Index", model);
		}

		[HttpGet]
		public IActionResult AddCoupen()
		{
			Discount_Coupen model = new Discount_Coupen();
			return PartialView("AddCoupen", model);
		}

		[HttpPost]
		public ActionResult AddCoupen(Discount_Coupen model)
		{
			if (ModelState.IsValid)
			{
				Discount_Coupen Temp = context.Set<Discount_Coupen>().SingleOrDefault(c => c.Coupen_Code == model.Coupen_Code.ToUpper());
				if (Temp == null)
				{
					Discount_Coupen discount_Coupen = new Discount_Coupen
					{
						Coupen_Code = model.Coupen_Code.ToUpper(),
						Coupen_Type=model.Coupen_Type,
						Discount=model.Discount,
						Duration=model.Duration,
						Status=true,
						AddDateTime = DateTime.Now,
						AddedBy = "Admin",



					};
					repodiscount.Insert(discount_Coupen);
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Coupen Already Exists");
					return PartialView("AddCoupen", model);
				}
			}
			else
			{
				ModelState.AddModelError(string.Empty, "There is some error");
				return PartialView("AddCoupen", model);
			}

		}

		[HttpGet]
		public IActionResult EditCoupen(long id)
		{
			Discount_Coupen model = new Discount_Coupen();

			Discount_Coupen discount_Coupen = repodiscount.Get(id);
			if (discount_Coupen != null)
			{
				model.Coupen_Code = discount_Coupen.Coupen_Code.ToUpper();
				model.Coupen_Type = discount_Coupen.Coupen_Type;
				model.Discount = discount_Coupen.Discount;
				model.Duration = discount_Coupen.Duration;


			}
			return PartialView("EditCoupen", model);
		}

		[HttpPost]
		public ActionResult EditCoupen(long id, Discount_Coupen model)
		{
			if (ModelState.IsValid)
			{
				Discount_Coupen discount_Coupen = repodiscount.Get(id);

				if (discount_Coupen != null)
				{
					discount_Coupen.Coupen_Code = model.Coupen_Code.ToUpper();
					discount_Coupen.Coupen_Type = model.Coupen_Type;
					discount_Coupen.Discount = model.Discount;
					discount_Coupen.Duration = model.Duration;
					discount_Coupen.ModifiedBy = "Admin";
					discount_Coupen.ModifiedDatime = DateTime.Now;
					repodiscount.Update(discount_Coupen);
				}
				return RedirectToAction("Index");
			}

			ModelState.AddModelError(string.Empty, "There is some error");
			return PartialView("EditCoupen", model);
		}


		[HttpGet]
		public IActionResult DeleteCoupen(long id)
		{
			Discount_Coupen model = new Discount_Coupen();

			Discount_Coupen discount_Coupen = repodiscount.Get(id);
			if (discount_Coupen != null)
			{
				model.Coupen_Code = discount_Coupen.Coupen_Code.ToUpper();
				model.Coupen_Type = discount_Coupen.Coupen_Type;
				model.Discount = discount_Coupen.Discount;
				model.Duration = discount_Coupen.Duration;


			}
			return PartialView("DeleteCoupen", model);
		}

		[HttpPost]
		public ActionResult DeleteCoupen(long id, Discount_Coupen form)
		{
			Discount_Coupen discount_Coupen = repodiscount.Get(id);
			if (discount_Coupen != null)
			{
				repodiscount.Delete(discount_Coupen);
			}
			return RedirectToAction("Index");
		}


	}
}
