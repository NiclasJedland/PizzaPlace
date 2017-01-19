using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaPlace.Entities;

namespace PizzaPlace.Models
{
	public static class DbInitialize
	{
		public static void Seed(DatabaseContext db)
		{
			db.Database.EnsureCreated();

			if(db.Foods.Any()) { return; }

			AddToDatabase(db);
		}

		private static void AddToDatabase(DatabaseContext db)
		{
			//types
			var typePizza = new FoodType { Type = "Pizza" };
			var typeSalad = new FoodType { Type = "Salad" };
			var typePasta = new FoodType { Type = "Pasta" };
			var typeOther = new FoodType { Type = "Other" };

			//foods
			var foodVesuvio = new Food { Name = "Vesuvio", FoodType = typePizza, Description = "", Price = 60 };
			var foodCalzone = new Food { Name = "Calzone", FoodType = typePizza, Description = "Folded pizza", Price = 70 };
			var foodHamsalad = new Food { Name = "Hamsalad", FoodType = typeSalad, Description = "", Price = 80 };
			var foodBolognese = new Food { Name = "Bolognese", FoodType = typePasta, Description = "", Price = 85 };
			var foodHamburger = new Food { Name = "Cheeseburger", FoodType = typeOther, Description = "", Price = 90 };

			//ingredients
			var salad = new Ingredient { IngredientName = "Salad", Price = 5 };
			var ham = new Ingredient { IngredientName = "Ham", Price = 15 };
			var onion = new Ingredient { IngredientName = "Onion", Price = 5 };
			var tomato = new Ingredient { IngredientName = "Tomato", Price = 5 };
			var paprika = new Ingredient { IngredientName = "Paprika", Price = 10 };
			var pasta = new Ingredient { IngredientName = "Pasta", Price = 10 };
			var mincedmeat = new Ingredient { IngredientName = "Minced meat", Price = 15 };
			var garlic = new Ingredient { IngredientName = "Garlic", Price = 5 };
			var cheese = new Ingredient { IngredientName = "Cheese", Price = 5 };
			var tomatosauce = new Ingredient { IngredientName = "Tomato sauce", Price = 5 };
			var burger = new Ingredient { IngredientName = "Hamburger", Price = 45 };

			//foodingredients

			var foodingredientslist = new List<FoodIngredient> {
				new FoodIngredient { Food = foodVesuvio, Ingredient = tomatosauce },
				new FoodIngredient { Food = foodVesuvio, Ingredient = cheese },
				new FoodIngredient { Food = foodVesuvio, Ingredient = ham },

				new FoodIngredient { Food = foodCalzone, Ingredient = tomatosauce },
				new FoodIngredient { Food = foodCalzone, Ingredient = cheese },
				new FoodIngredient { Food = foodCalzone, Ingredient = ham },

				new FoodIngredient { Food = foodHamsalad, Ingredient = salad },
				new FoodIngredient { Food = foodHamsalad, Ingredient = cheese },
				new FoodIngredient { Food = foodHamsalad, Ingredient = onion },
				new FoodIngredient { Food = foodHamsalad, Ingredient = tomato },
				new FoodIngredient { Food = foodHamsalad, Ingredient = paprika },
				new FoodIngredient { Food = foodHamsalad, Ingredient = ham },

				new FoodIngredient { Food = foodBolognese, Ingredient = mincedmeat },
				new FoodIngredient { Food = foodBolognese, Ingredient = pasta },
				new FoodIngredient { Food = foodBolognese, Ingredient = onion },
				new FoodIngredient { Food = foodBolognese, Ingredient = garlic },

				new FoodIngredient { Food = foodHamburger, Ingredient = burger },
				new FoodIngredient { Food = foodHamburger, Ingredient = onion },
				new FoodIngredient { Food = foodHamburger, Ingredient = tomato },
				new FoodIngredient { Food = foodHamburger, Ingredient = salad }
			};

			foreach(var item in foodingredientslist)
			{
				db.FoodIngredients.Add(item);
			}
			db.SaveChanges();

			//roles

			var rolesRegularUser = new Role { Discount = 1.00d, UserRole = UserRole.RegularUser };
			var rolesPremiumUser = new Role { Discount = 0.80d, UserRole = UserRole.PremiumUser };
			var rolesAdmin = new Role { Discount = 0.80d, UserRole = UserRole.Admin };

			//customers
			var customerZalchion = new Customer
			{
				AccountName = "Zalchion",
				FirstName = "Zalchion",
				LastName = "Dracho",
				Address = "Vana'diel",
				City = "Windurst",
				Email = "Zalchion@gmail.com",
				Password = "123456789",
				Phone = "000-111222",
				Zip = "12345",
				Role = rolesAdmin,
				PremiumCoins = 100
			};

			var customerNiclas = new Customer
			{
				AccountName = "Niclas",
				FirstName = "Niclas",
				LastName = "Jedland",
				Address = "Bruno Liljeforsgatan 39",
				City = "Uppsala",
				Email = "niclasjedland@gmail.com",
				Password = "987654321",
				Phone = "0736-171353",
				Zip = "75429",
				Role = rolesPremiumUser,
				PremiumCoins = 30
			};

			var customerRandom = new Customer
			{
				AccountName = "RandomAccount",
				FirstName = "RandomFirstName",
				LastName = "RandomLastName",
				Address = "RandomAddress",
				City = "RandomCity",
				Email = "Random@random.random",
				Password = "RandomPassword",
				Phone = "RandomPhone",
				Zip = "RandomZip",
				Role = rolesRegularUser,
				PremiumCoins = 0
			};

			//orders
			var orderZal1 = new Order { OrderDate = DateTime.Parse("2011-11-11"), Customer = customerZalchion }; 
			var orderZal2 = new Order { OrderDate = DateTime.Parse("2013-12-24"), Customer = customerZalchion }; 

			var orderNiclas1 = new Order { OrderDate = DateTime.Parse("2011-11-11"), Customer = customerNiclas }; 
			var orderNiclas2 = new Order { OrderDate = DateTime.Parse("2016-11-11"), Customer = customerNiclas };

			var orderRandom1 = new Order { OrderDate = DateTime.Parse("1000-10-10"), Customer = customerRandom };

			//foodorder
			var foodOrderList = new List<FoodOrder>()
			{
				new FoodOrder { Order = orderZal1, Food = foodVesuvio, Quantity = 5 },
				new FoodOrder { Order = orderZal2, Food = foodHamburger, Quantity = 5 },

				new FoodOrder { Order = orderNiclas1, Food = foodVesuvio, Quantity = 2 },
				new FoodOrder { Order = orderNiclas1, Food = foodCalzone, Quantity = 1 },
				new FoodOrder { Order = orderNiclas1, Food = foodBolognese, Quantity = 2 },

				new FoodOrder { Order = orderNiclas2, Food = foodVesuvio, Quantity = 2 },
				new FoodOrder { Order = orderNiclas2, Food = foodHamsalad, Quantity = 1 },
				new FoodOrder { Order = orderNiclas2, Food = foodBolognese, Quantity = 3 },

				new FoodOrder { Order = orderRandom1, Food = foodHamsalad, Quantity = 10 }
			};

			//Calculate Cost
			orderZal1.Cost = foodOrderList.Where(s => s.Order == orderZal1).Sum(s => s.Food.Price * s.Quantity);
			orderZal2.Cost = foodOrderList.Where(s => s.Order == orderZal2).Sum(s => s.Food.Price * s.Quantity);

			orderNiclas1.Cost = foodOrderList.Where(s => s.Order == orderNiclas1).Sum(s => s.Food.Price * s.Quantity);
			orderNiclas2.Cost = foodOrderList.Where(s => s.Order == orderNiclas2).Sum(s => s.Food.Price * s.Quantity);

			orderRandom1.Cost = foodOrderList.Where(s => s.Order == orderRandom1).Sum(s => s.Food.Price * s.Quantity);

			foreach(var item in foodOrderList)
			{
				db.FoodOrders.Add(item);
			}
			db.SaveChanges();
		}
	}
}
