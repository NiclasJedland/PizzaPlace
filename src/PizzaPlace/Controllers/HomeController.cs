using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Entities;
using PizzaPlace.Models;

namespace PizzaPlace.Controllers
{
	public class HomeController : Controller
	{
		private DatabaseContext db;
		public HomeController(DatabaseContext _context)
		{
			db = _context;
		}

		public IActionResult Index(string searchType)
		{
			DbInitialize.Seed(db);

			var search = searchType?.Trim().ToLower();
			var viewModel = new ViewModel();

			viewModel.Customers = db.Customers.ToList();
			viewModel.Foods = db.Foods.ToList();
			viewModel.FoodIngredients = db.FoodIngredients.ToList();
			viewModel.FoodOrders = db.FoodOrders.ToList();
			viewModel.FoodTypes = db.FoodTypes.ToList();
			viewModel.Ingredients = db.Ingredients.ToList();
			viewModel.Orders = db.Orders.ToList();
			viewModel.Roles = db.Roles.ToList();

			ViewBag.search = "";

			return View(viewModel);
		}

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult AddToCart(int id)
		{
			var food = db.Foods.Single(s => s.Id== id);
			
			return RedirectToAction("Index");
		}



	}
}
