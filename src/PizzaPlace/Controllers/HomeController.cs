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


		public IActionResult Index()
        {
			var viewModel = new ViewModel();

			List<FoodType> foodTypes = db.FoodTypes.ToList();
			List<Ingredient> ingredients = db.Ingredients.ToList();
			List<Food> foods = db.Foods.ToList();
			List<Customer> customers = db.Customers.ToList();
			List<FoodIngredient> foodIngredients = db.FoodIngredients.ToList();

			viewModel.FoodTypes = foodTypes;
			viewModel.Ingredients = ingredients;
			viewModel.Foods = foods;
			viewModel.Customers = customers;
			viewModel.FoodIngredients = foodIngredients;

			ViewBag.search = "";

			return View(viewModel);
        }

		[HttpPost]
		public IActionResult Index(string search)
		{
			var viewModel = new ViewModel();





			List<FoodType> foodTypes = db.FoodTypes.ToList();
			List<Ingredient> ingredients = db.Ingredients.ToList();
			List<Food> foods = db.Foods.ToList();
			List<Customer> customers = db.Customers.ToList();
			List<FoodIngredient> foodIngredients = db.FoodIngredients.ToList();

			viewModel.FoodTypes = foodTypes;
			viewModel.Ingredients = ingredients;
			viewModel.Foods = foods;
			viewModel.Customers = customers;
			viewModel.FoodIngredients = foodIngredients;

			return View(viewModel);
		}



	}
}
