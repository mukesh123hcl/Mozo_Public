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
	public class GstController : Controller
	{
		private IServiceRepository<GST_Config> repogst;
		private IServiceRepository<ServiceTypes> reposervicestype;
		private readonly ILogger<GstController> _logger;
		private Mozo_Data_Context context;

		public GstController(IServiceRepository<GST_Config> repogst, IServiceRepository<ServiceTypes> reposervicestype, ILogger<GstController> logger, Mozo_Data_Context context)
		{
			this.repogst = repogst;
			this.reposervicestype = reposervicestype;
			_logger = logger;
			this.context = context;
		}

		public IActionResult Index()
		{
			List<GST_View> model = new List<GST_View>();
			repogst.GetAll().ToList().ForEach(b => {
				GST_View gst = new GST_View
				{
					Id = b.Id,
					C_GST = b.C_GST,
					S_GST=b.S_GST,
					AddDateTime = b.AddDateTime,
					ModifiedBy = b.ModifiedBy,

				};
				ServiceTypes serviceTypes = reposervicestype.Get(b.Service_Type_Id);
				gst.Sevice_type = serviceTypes.Service_Type_Name;
				model.Add(gst);
			});
			return View("Index", model);
		}

		[HttpGet]
		public IActionResult AddGst()
		{
			GST_View model = new GST_View();
			model.Service_Types = reposervicestype.GetAll().Select(a => new SelectListItem
			{
				Text = a.Service_Type_Name,
				Value = a.Id.ToString()
			}).ToList();
			return PartialView("AddGst", model);
		}

		[HttpPost]
		public ActionResult AddGst(GST_View model)
		{
			if (ModelState.IsValid)
			{
				GST_Config Temp = context.Set<GST_Config>().SingleOrDefault(c => c.Service_Type_Id == model.Service_Type_Id);
				if (Temp == null)
				{
					GST_Config gST_Config = new GST_Config
					{
						Service_Type_Id = model.Service_Type_Id,
						S_GST = model.S_GST,
						C_GST=model.C_GST,
						AddDateTime = DateTime.Now,
						ModifiedDatime = DateTime.Now,
						AddedBy = "Admin",



					};
					repogst.Insert(gST_Config);
					return RedirectToAction("Index");
				}
				else
				{

					model.Service_Types = reposervicestype.GetAll().Select(a => new SelectListItem
					{
						Text = a.Service_Type_Name,
						Value = a.Id.ToString()
					}).ToList();
					ModelState.AddModelError(string.Empty, "GST Already Configured");
					return PartialView("AddGst", model);
				}
			}
			else
			{
				model.Service_Types = reposervicestype.GetAll().Select(a => new SelectListItem
				{
					Text = a.Service_Type_Name,
					Value = a.Id.ToString()
				}).ToList();

				ModelState.AddModelError(string.Empty, "There is some error");
				return PartialView("AddGst", model);
			}

		}

		[HttpGet]
		public PartialViewResult EditGst(long id)
		{
			GST_View model = new GST_View();
			model.Service_Types = reposervicestype.GetAll().Select(a => new SelectListItem
			{
				Text = a.Service_Type_Name,
				Value = a.Id.ToString()
			}).ToList();
			GST_Config gst = repogst.Get(id);
			if (gst != null)
			{
				model.S_GST = gst.S_GST;
				model.C_GST = gst.C_GST;
				model.Service_Type_Id = gst.Service_Type_Id;
			}
			return PartialView("EditGst", model);
		}

		[HttpPost]
		public ActionResult EditGst(long id, GST_View model)
		{
			if (ModelState.IsValid)
			{
				GST_Config gST_Config = repogst.Get(id);

				if (gST_Config != null)
				{
					gST_Config.Service_Type_Id = model.Service_Type_Id;
					gST_Config.S_GST = model.S_GST;
					gST_Config.C_GST = model.C_GST;
					gST_Config.ModifiedBy = "Admin";
					gST_Config.ModifiedDatime = DateTime.Now;
					repogst.Update(gST_Config);
				}
				return RedirectToAction("Index");
			}
			else
			{
				model.Service_Types = reposervicestype.GetAll().Select(a => new SelectListItem
				{
					Text = a.Service_Type_Name,
					Value = a.Id.ToString()
				}).ToList();
			}

			ModelState.AddModelError(string.Empty, "There is some error");
			return PartialView("EditServices", model);
		}

		[HttpGet]
		public PartialViewResult DeleteGst(long id)
		{
			GST_View model = new GST_View();
			model.Service_Types = reposervicestype.GetAll().Select(a => new SelectListItem
			{
				Text = a.Service_Type_Name,
				Value = a.Id.ToString()
			}).ToList();
			GST_Config gst = repogst.Get(id);
			if (gst != null)
			{
				model.S_GST = gst.S_GST;
				model.C_GST = gst.C_GST;
				model.Service_Type_Id = gst.Service_Type_Id;
			}
			return PartialView("DeleteGst", model);
		}

		[HttpPost]
		public ActionResult DeleteGst(long id, GST_Config form)
		{
			GST_Config gST_Config = repogst.Get(id);
			if (gST_Config != null)
			{
				repogst.Delete(gST_Config);
			}
			return RedirectToAction("Index");
		}
	}
}
