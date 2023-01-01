using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MozoApp.Areas.Booking.Controllers
{
	[Area("Booking")]
	public class BookingController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
