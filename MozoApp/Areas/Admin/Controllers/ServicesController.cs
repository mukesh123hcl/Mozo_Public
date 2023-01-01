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
	public class ServicesController : Controller
	{
		private IServiceRepository<Services> reposevices;
		private IServiceRepository<ServiceTypes> reposervicestype;
		private readonly ILogger<ServicesController> _logger;
		private Mozo_Data_Context context;

		public ServicesController(IServiceRepository<Services> reposevices, IServiceRepository<ServiceTypes> reposervicestype, ILogger<ServicesController> logger, Mozo_Data_Context context)
		{
			this.reposevices = reposevices;
			this.reposervicestype = reposervicestype;
			_logger = logger;
			this.context = context;
		}


		public IActionResult Index()
		{
			List<Services_View> model = new List<Services_View>();
			reposevices.GetAll().ToList().ForEach(b => {
				Services_View service = new Services_View
				{
					Id = b.Id,
					Service = b.Service_Name,
					AddDateTime = b.AddDateTime,
					ModifiedBy = b.ModifiedBy,

				};
				ServiceTypes serviceTypes = reposervicestype.Get(b.Service_Type_Id);
				service.Sevice_type = serviceTypes.Service_Type_Name;
				model.Add(service);
			});
			return View("Index", model);
		}

		[HttpGet]
		public IActionResult AddServices()
		{
			Services_View model = new Services_View();
			model.Service_Types = reposervicestype.GetAll().Select(a => new SelectListItem
			{
				Text = a.Service_Type_Name,
				Value = a.Id.ToString()
			}).ToList();
			return PartialView("AddServices", model);
		}

		[HttpPost]
		public ActionResult AddServices(Services_View model)
		{
			if (ModelState.IsValid)
			{
				Services Temp = context.Set<Services>().SingleOrDefault(c => (c.Service_Name == model.Service) && (c.Service_Type_Id == model.Service_Type_Id));
				if (Temp == null)
				{
					Services services = new Services
					{
						Service_Type_Id = model.Service_Type_Id,
						Service_Name = model.Service,
						AddDateTime = DateTime.Now,
						ModifiedDatime = DateTime.Now,
						AddedBy = "Admin",



					};
					reposevices.Insert(services);
					return RedirectToAction("Index");
				}
				else
				{
			
					model.Service_Types = reposervicestype.GetAll().Select(a => new SelectListItem
					{
						Text = a.Service_Type_Name,
						Value = a.Id.ToString()
					}).ToList();
					ModelState.AddModelError(string.Empty, "Service Already Exists");
					return PartialView("AddServices", model);
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
				return PartialView("AddServices", model);
			}

		}

		[HttpGet]
		public PartialViewResult EditServices(long id)
		{
			Services_View model = new Services_View();
			model.Service_Types = reposervicestype.GetAll().Select(a => new SelectListItem
			{
				Text = a.Service_Type_Name,
				Value = a.Id.ToString()
			}).ToList();
			Services services = reposevices.Get(id);
			if (services != null)
			{
				model.Service = services.Service_Name;

				model.Service_Type_Id = services.Service_Type_Id;
			}
			return PartialView("EditServices", model);
		}

		[HttpPost]
		public ActionResult EditServices(long id, Services_View model)
		{
			if (ModelState.IsValid)
			{
				Services services = reposevices.Get(id);

				if (services != null)
				{
					services.Service_Type_Id = model.Service_Type_Id;
					services.Service_Name = model.Service;
					services.ModifiedBy = "Admin";
					services.ModifiedDatime = DateTime.Now;
					reposevices.Update(services);
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
		public PartialViewResult DeleteServices(long id)
		{
			Services_View model = new Services_View();
			model.Service_Types = reposervicestype.GetAll().Select(a => new SelectListItem
			{
				Text = a.Service_Type_Name,
				Value = a.Id.ToString()
			}).ToList();
			Services services = reposevices.Get(id);
			if (services != null)
			{
				model.Service = services.Service_Name;

				model.Service_Type_Id = services.Service_Type_Id;
			}
			return PartialView("DeleteServices", model);
		}

		[HttpPost]
		public ActionResult DeleteServices(long id, Services form)
		{
			Services services = reposevices.Get(id);
			if (services != null)
			{
				reposevices.Delete(services);
			}
			return RedirectToAction("Index");
		}
	}
}
