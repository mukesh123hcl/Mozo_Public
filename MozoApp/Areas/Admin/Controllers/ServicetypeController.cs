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
	public class ServicetypeController : Controller
	{
		private Mozo_Data_Context context;


		private IServiceRepository<ServiceTypes> reposervicetype;
		private readonly ILogger<ServicetypeController> _logger;


		public ServicetypeController(IServiceRepository<ServiceTypes> reposervicetype, ILogger<ServicetypeController> logger, Mozo_Data_Context context)
		{
			this.reposervicetype = reposervicetype;
			_logger = logger;
			this.context = context;
		}
		public IActionResult Index()
		{
			List<ServiceTypes> model = new List<ServiceTypes>();
			reposervicetype.GetAll().ToList().ForEach(a => {
				ServiceTypes serviceTypes = new ServiceTypes
				{
					Id = a.Id,
					Service_Type_Name = a.Service_Type_Name,
					AddDateTime = a.AddDateTime,
					ModifiedDatime = a.ModifiedDatime
				};

				model.Add(serviceTypes);
			});
			return View("Index", model);
		}

		[HttpGet]
		public IActionResult AddServicetype()
		{
			ServiceTypes model = new ServiceTypes();
			return PartialView("AddServicetype", model);
		}

		[HttpPost]
		public ActionResult AddServicetype(ServiceTypes model)
		{
			if (ModelState.IsValid)
			{
				ServiceTypes Temp = context.Set<ServiceTypes>().SingleOrDefault(c => c.Service_Type_Name == model.Service_Type_Name);
				if (Temp == null)
				{
					ServiceTypes serviceTypes = new ServiceTypes
					{
						Service_Type_Name = model.Service_Type_Name,
						AddDateTime = DateTime.Now,
						AddedBy = "Admin",



					};
					reposervicetype.Insert(serviceTypes);
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Service Type Already Exists");
					return PartialView("AddServicetype", model);
				}
			}
			else
			{
				ModelState.AddModelError(string.Empty, "There is some error");
				return PartialView("AddServicetype", model);
			}

		}

		[HttpGet]
		public IActionResult EditServicetype(long id)
		{
			ServiceTypes model = new ServiceTypes();

			ServiceTypes serviceTypes = reposervicetype.Get(id);
			if (serviceTypes != null)
			{
				model.Service_Type_Name = serviceTypes.Service_Type_Name;


			}
			return PartialView("EditServicetype", model);
		}

		[HttpPost]
		public ActionResult EditServicetype(long id, ServiceTypes model)
		{
			if (ModelState.IsValid)
			{
				ServiceTypes serviceTypes = reposervicetype.Get(id);

				if (serviceTypes != null)
				{
					serviceTypes.Service_Type_Name = model.Service_Type_Name;
					serviceTypes.ModifiedBy = "Admin";
					serviceTypes.ModifiedDatime = DateTime.Now;
					reposervicetype.Update(serviceTypes);
				}
				return RedirectToAction("Index");
			}

			ModelState.AddModelError(string.Empty, "There is some error");
			return PartialView("EditServicetype", model);
		}

		[HttpGet]
		public PartialViewResult DeleteServicetype(long id)
		{

			ServiceTypes model = new ServiceTypes();

			ServiceTypes serviceTypes = reposervicetype.Get(id);
			if (serviceTypes != null)
			{
				model.Service_Type_Name = serviceTypes.Service_Type_Name;


			}
			return PartialView("DeleteServicetype", model);
		}
		[HttpPost]
		public ActionResult DeleteServicetype(long id, ServiceTypes form)
		{
			ServiceTypes serviceTypes = reposervicetype.Get(id);
			if (serviceTypes != null)
			{
				reposervicetype.Delete(serviceTypes);
			}
			return RedirectToAction("Index");
		}
	}
}
