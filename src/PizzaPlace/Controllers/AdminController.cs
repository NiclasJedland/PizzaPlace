using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Entities;
using Microsoft.AspNetCore.Authorization;


namespace PizzaPlace.Controllers
{
	[Authorize(Policy = "AdministratorOnly")]
	public class AdminController : Controller
    {
		private DatabaseContext db;
		public AdminController(DatabaseContext _context)
		{
			db = _context;
		}
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
