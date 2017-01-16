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

			db.SaveChanges();
		}

		private static void AddToDatabase(DatabaseContext db)
		{
			//types
			var foodTypePizza = new FoodType { Type = "Pizza" };
			var foodTypeSalad = new FoodType { Type = "Salad" };
			var foodTypePasta = new FoodType { Type = "Pasta" };
			var foodTypeOther = new FoodType { Type = "Other" };

			//foods
			var vesuvio = new Food { Name = "Vesuvio", FoodType = foodTypePizza, Description = "", Price = 60 };
			var calzone = new Food { Name = "Calzone", FoodType = foodTypePizza, Description = "Folded pizza", Price = 70 };
			var hamsalad = new Food { Name = "Hamsalad", FoodType = foodTypeSalad, Description = "", Price = 80 };
			var bolognese = new Food { Name = "Bolognese", FoodType = foodTypePasta, Description = "", Price = 85 };
			var hamburger = new Food { Name = "Cheeseburger", FoodType = foodTypeOther, Description = "", Price = 90 };

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
				new FoodIngredient { Food = vesuvio, Ingredient = tomatosauce },
				new FoodIngredient { Food = vesuvio, Ingredient = cheese },
				new FoodIngredient { Food = vesuvio, Ingredient = ham },

				new FoodIngredient { Food = calzone, Ingredient = tomatosauce },
				new FoodIngredient { Food = calzone, Ingredient = cheese },
				new FoodIngredient { Food = calzone, Ingredient = ham },

				new FoodIngredient { Food = hamsalad, Ingredient = salad },
				new FoodIngredient { Food = hamsalad, Ingredient = cheese },
				new FoodIngredient { Food = hamsalad, Ingredient = onion },
				new FoodIngredient { Food = hamsalad, Ingredient = tomato },
				new FoodIngredient { Food = hamsalad, Ingredient = paprika },
				new FoodIngredient { Food = hamsalad, Ingredient = ham },

				new FoodIngredient { Food = bolognese, Ingredient = mincedmeat },
				new FoodIngredient { Food = bolognese, Ingredient = pasta },
				new FoodIngredient { Food = bolognese, Ingredient = onion },
				new FoodIngredient { Food = bolognese, Ingredient = garlic },

				new FoodIngredient { Food = hamburger, Ingredient = burger },
				new FoodIngredient { Food = hamburger, Ingredient = onion },
				new FoodIngredient { Food = hamburger, Ingredient = tomato },
				new FoodIngredient { Food = hamburger, Ingredient = salad }
			};

			foreach(var item in foodingredientslist)
			{
				db.FoodIngredients.Add(item);
			}
			db.SaveChanges();

			//customers
			var zalchion = new Customer
			{
				AccountName = "Zalchion",
				FirstName = "Zalchion",
				LastName = "Dracho",
				Address = "Vana'diel",
				City = "Windurst",
				Email = "Zalchion@gmail.com",
				Password = "123456789",
				Phone = "000-111222",
				Zip = "12345"
			};

			//orders
			var zalorder1 = new Order { Cost = 300, OrderDate = DateTime.Parse("2011-11-11"), Customer = zalchion };

			//foodorder
			var zalfoodOrder1 = new FoodOrder { Order = zalorder1, Food = vesuvio, Quantity = 5 };

			db.FoodOrder.Add(zalfoodOrder1);







			//---------------------------------------------------
		}



	}
}
