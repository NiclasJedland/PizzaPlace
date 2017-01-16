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
			List<FoodType> foodTypes = db.FoodTypes.ToList();
			List<Ingredient> ingredients = db.Ingredients.ToList();
			List<Food> foods = db.Foods.ToList();
			List<Customer> customers = db.Customers.ToList();
			List<FoodIngredient> foodIngredients = db.FoodIngredients.ToList();

			List<object> objects = new List<object>();

			
			
			

			if(!string.IsNullOrEmpty(searchType))
			{
				//foods = foods.Where(s => s.Type.Name == searchType).ToList();
			}

			//if(viewModel.Cart.Foods.Count == 0)
			//{
			//	Cart cart = new Cart();
			//	viewModel.Cart = cart;
			//}

			viewModel.FoodTypes = foodTypes;
			viewModel.Ingredients = ingredients;
			viewModel.Foods = foods;
			viewModel.Customers = customers;
			viewModel.FoodIngredients = foodIngredients;

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
