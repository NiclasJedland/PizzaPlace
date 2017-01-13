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
			var search = searchType?.Trim().ToLower();
			var viewModel = new ViewModel();
			List<FoodType> foodTypes;
			List<Ingredient> ingredients;
			List<Food> foods;
			List<Customer> customers;
			List<FoodIngredient> foodIngredients;
			


			foodTypes = db.FoodTypes.ToList();
			ingredients = db.Ingredients.ToList();
			foods = db.Foods.ToList();
			customers = db.Customers.ToList();
			foodIngredients = db.FoodIngredients.ToList();

			if(!string.IsNullOrEmpty(searchType))
			{
				foods = foods.Where(s => s.Type.Type == searchType).ToList();
			}

			if(viewModel.Cart.Food.Count == 0)
			{
				Cart cart = new Cart();
				viewModel.Cart = cart;
			}

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
			// Retrieve the album from the database
			var food = db.Foods.Single(s => s.Id== id);

			// Add it to the shopping cart
			var cart = ShoppingCart.GetCart(this.HttpContext);

			cart.AddToCart(addedAlbum);

			// Go back to the main store page for more shopping
			return RedirectToAction("Index");
		}


	}
}
