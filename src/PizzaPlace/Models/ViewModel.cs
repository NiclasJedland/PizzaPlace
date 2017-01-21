using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaPlace.Entities;

namespace PizzaPlace.Models
{
	public class ViewModel
	{
		public List<Customer> Customers { get; set; }
		public List<Food> Foods { get; set; }
		public List<FoodIngredient> FoodIngredients { get; set; }
		public List<FoodOrder> FoodOrders { get; set; }
		public List<FoodType> FoodTypes { get; set; }
		public List<Ingredient> Ingredients { get; set; }
		public List<Order> Orders { get; set; }
		public List<Role> Roles { get; set; }
		public List<CartItem> CartItems { get; set; }


		public Customer Customer { get; set; }
		public Food Food { get; set; }
		public FoodIngredient FoodIngredient { get; set; }
		public FoodOrder FoodOrder { get; set; }
		public FoodType FoodType { get; set; }
		public Ingredient Ingredient { get; set; }
		public Order Order { get; set; }
		public Role Role { get; set; }
		public CartItem CartItem { get; set; }

		public static ViewModel GetAllDbItems(DatabaseContext db)
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

			return viewModel;
		}

		public static ViewModel GetAllCustomers(DatabaseContext db)
		{
			var viewModel = new ViewModel();
			viewModel.Customers = db.Customers.ToList();
			return viewModel;
		}

		public static ViewModel GetAllFood(DatabaseContext db)
		{
			var viewModel = new ViewModel();
			viewModel.Foods = db.Foods.ToList();
			return viewModel;
		}

		public static ViewModel GetAllFoodIngredients(DatabaseContext db)
		{
			var viewModel = new ViewModel();
			viewModel.FoodIngredients = db.FoodIngredients.ToList();
			return viewModel;
		}

		public static ViewModel GetAllFoodOrders(DatabaseContext db)
		{
			var viewModel = new ViewModel();
			viewModel.FoodOrders = db.FoodOrders.ToList();
			return viewModel;
		}

		public static ViewModel GetAllFoodTypes(DatabaseContext db)
		{
			var viewModel = new ViewModel();
			viewModel.FoodTypes = db.FoodTypes.ToList();
			return viewModel;
		}

		public static ViewModel GetAllIngredients(DatabaseContext db)
		{
			var viewModel = new ViewModel();
			viewModel.Ingredients = db.Ingredients.ToList();
			return viewModel;
		}

		public static ViewModel GetAllOrders(DatabaseContext db)
		{
			var viewModel = new ViewModel();
			viewModel.Orders = db.Orders.ToList();
			return viewModel;
		}

		public static ViewModel GetAllRoles(DatabaseContext db)
		{
			var viewModel = new ViewModel();
			viewModel.Roles = db.Roles.ToList();
			return viewModel;
		}

		public static ViewModel GetAllCartItems(DatabaseContext db)
		{
			var viewModel = new ViewModel();
			viewModel.CartItems = db.CartItems.ToList();
			return viewModel;
		}

	}
}
