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
	[Authorize(Policy = "MembersOnly")]
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

			return View(viewModel);
		}
		
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

		public IActionResult RemoveFromCart(int id)
		{
			var removeCartItem = db.CartItems.SingleOrDefault(s => s.Id == id);

			db.CartItems.Remove(removeCartItem);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		public IActionResult ResetCart()
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

			var currentUserId = User.Claims.SingleOrDefault(s => s.Type == "CustomerId");
			var currentUserCart = viewModel.CartItems.Where(s => s.Customer.Id.ToString() == currentUserId.Value);


			foreach(var item in currentUserCart)
			{
				db.CartItems.Remove(item);
			}

			db.SaveChanges();

			return RedirectToAction("Index");
		}

		public IActionResult Checkout()
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
			
			var currentUserId = User.Claims.SingleOrDefault(s => s.Type == "CustomerId");
			var currentUserCart = viewModel.CartItems.Where(s => s.Customer.Id.ToString() == currentUserId.Value);
			var currentUser = viewModel.Customers.SingleOrDefault(s => s.Id.ToString() == currentUserId.Value);
			
			var currentOrderPrice = currentUserCart.OrderBy(s=>s.Food.Price).Sum(s => s.Food.Price);
			
			if(currentUser.PremiumCoins >= 100)
			{
				currentUser.PremiumCoins -= 100;
				currentOrderPrice -= currentUserCart.OrderBy(s => s.Food.Price).First().Food.Price;
			}

			if(currentUser.Role.UserRole == UserRole.PremiumUser || currentUser.Role.UserRole == UserRole.Admin)
			{	
				currentUser.PremiumCoins += 10 * currentUserCart.Count();
				TempData["PremiumCoins"] = "Congratulations you earned " + (10 * currentUserCart.Count()) 
					+ " premium coins.\nYour total premium coins are: " + currentUser.PremiumCoins;
				db.Customers.Update(currentUser);
				db.SaveChanges();
			}

			var newOrder = new Order();
			newOrder.Cost = currentOrderPrice * Convert.ToDecimal(currentUser.Role.Discount);
			newOrder.Customer = currentUser;
			newOrder.OrderDate = DateTime.Now;

			db.Orders.Add(newOrder);
			db.SaveChanges();

			TempData["Checkout"] = "True";
			return RedirectToAction("Index");
		}


	}
}
