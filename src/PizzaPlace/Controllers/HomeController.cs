using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaPlace.Entities;
using PizzaPlace.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace PizzaPlace.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		private DatabaseContext db;
		public HomeController(DatabaseContext _context)
		{
			db = _context;
		}

		const string claimLoginCookie = "LoginCookie";
		const string claimCustomerId = "CustomerId";
		const string claimAccountName = "AccountName";
		const string claimPassword = "Password";
		const string claimRegularUser = "RegularUser";
		const string claimMember = "Member";

		public IActionResult Index(string searchType, string disable)
		{
			DbInitialize.Seed(db);

			var viewModel = new ViewModel();

			var search = searchType?.Trim().ToLower();

			viewModel.Customers = db.Customers.ToList();
			viewModel.Foods = db.Foods.ToList();
			viewModel.FoodIngredients = db.FoodIngredients.ToList();
			viewModel.FoodOrders = db.FoodOrders.ToList();
			viewModel.FoodTypes = db.FoodTypes.ToList();
			viewModel.Ingredients = db.Ingredients.ToList();
			viewModel.Orders = db.Orders.ToList();
			viewModel.Roles = db.Roles.ToList();
			viewModel.CartItems = db.CartItems.ToList();

			ViewBag.search = searchType;

			if(disable == "disable")
				ViewBag.disable = "disable";
			else
				ViewBag.disable = "enable";

			var cartitems = db.CartItems.ToList();




			//viewModel.CartItems


			return View(viewModel);
		}
		


		[Authorize(Policy = "MembersOnly")]
		public IActionResult AddToCart(int? id)
		{
			var claim = User.Claims.SingleOrDefault(s => s.Type == claimCustomerId);
		
			if(claim != null)
			{
				var viewModel = new ViewModel();

				viewModel.Customers = db.Customers.ToList();
				viewModel.Foods = db.Foods.ToList();
				viewModel.FoodIngredients = db.FoodIngredients.ToList();
				viewModel.FoodOrders = db.FoodOrders.ToList();
				viewModel.FoodTypes = db.FoodTypes.ToList();
				viewModel.Ingredients = db.Ingredients.ToList();
				viewModel.Orders = db.Orders.ToList();
				viewModel.Roles = db.Roles.ToList();
				viewModel.CartItems = db.CartItems.ToList();

				var newFood = viewModel.Foods.FirstOrDefault(s => s.Id == id);

				var cart = new CartItem { DateCreated = DateTime.Now, Food = newFood };

				var customer = db.Customers.Include(s => s.CartItems)
					.SingleOrDefault(s => s.Id == int.Parse(claim.Value));

				customer.CartItems.Add(cart);
				db.Customers.Update(customer);
				db.SaveChanges();

			}
			return RedirectToAction("Index");
		}

		[Authorize(Policy = "MembersOnly")]
		public IActionResult RemoveFromCart(int id)
		{
			var removeCartItem = db.CartItems.SingleOrDefault(s => s.Id == id);

			db.CartItems.Remove(removeCartItem);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		[Authorize(Policy = "MembersOnly")]
		public IActionResult ResetCart()
		{
			var cartItems = db.CartItems.ToList();

			foreach(var item in cartItems)
			{
				db.CartItems.Remove(item);
			}

			db.SaveChanges();

			return RedirectToAction("Index");
		}

		[Authorize(Policy = "MembersOnly")]
		public IActionResult Checkout()
		{
			TempData["Checkout"] = "True";

			return RedirectToAction("Index");
		}


	}
}
