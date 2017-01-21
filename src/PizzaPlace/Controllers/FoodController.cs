using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.Entities;
using PizzaPlace.Models;

namespace PizzaPlace.Controllers
{
	[Authorize(Policy = "AdministratorOnly")]
	public class FoodController : Controller
	{
		private DatabaseContext db;
		public FoodController(DatabaseContext _context)
		{
			db = _context;
		}
		public IActionResult Index()
		{
			var vm = ViewModel.GetAllDbItems(db);

			return View(vm);
		}

		[HttpGet]
		public IActionResult Delete(Food food)
		{
			var vm = ViewModel.GetAllDbItems(db);

			var deleted = vm.Foods.SingleOrDefault(s => s.Id == food.Id);

			db.Foods.Remove(deleted);
			db.SaveChanges();

			return RedirectToAction("Index", "Food");
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			var vm = ViewModel.GetAllDbItems(db);

			vm.Food = vm.Foods.SingleOrDefault(s => s.Id == id);
			vm.FoodType = new FoodType();
			vm.FoodIngredient = new FoodIngredient();

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Food food, FoodType foodType, List<string> ingredients)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if(!ModelState.IsValid)
				return View();

			var foodTypes = ViewModel.GetAllFoodTypes(db);
			var getType = foodTypes.FoodTypes.FirstOrDefault(s => s.Type == foodType.Type);
			food.FoodType = getType;

			var getIngredients = ViewModel.GetAllIngredients(db);
			food.FoodIngredients = new List<FoodIngredient>();

			foreach(var item in ingredients)
			{
				var foodingredient = new FoodIngredient();
				foodingredient.Ingredient = getIngredients.Ingredients.SingleOrDefault(s => s.Id.ToString() == item);
				foodingredient.Food = food;
				food.FoodIngredients.Add(foodingredient);
			}

			db.Foods.Update(food);
			db.SaveChanges();

			return RedirectToAction("Index", "Food");
		}

		[HttpGet]
		public IActionResult Create()
		{
			var vm = ViewModel.GetAllDbItems(db);
			vm.Food = new Food();
			vm.Food.FoodType = new FoodType();
			vm.Food.FoodIngredients = new List<FoodIngredient>();

			vm.FoodType = new FoodType();
			vm.FoodIngredient = new FoodIngredient();
			
			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Food food, FoodType foodType, List<string> ingredients)
		{
			if(!ModelState.IsValid)
				return View();
			
			var foodTypes = ViewModel.GetAllFoodTypes(db);
			var getType = foodTypes.FoodTypes.FirstOrDefault(s => s.Type == foodType.Type);
			food.FoodType = getType;
			
			var getIngredients = ViewModel.GetAllIngredients(db);
			food.FoodIngredients = new List<FoodIngredient>();

			foreach(var item in ingredients)
			{
				var foodingredient = new FoodIngredient();
				foodingredient.Ingredient = getIngredients.Ingredients.SingleOrDefault(s => s.Id.ToString() == item);
				foodingredient.Food = food;
				food.FoodIngredients.Add(foodingredient);
			}

			db.Foods.Add(food);
			db.SaveChanges();

			return RedirectToAction("Index", "Food");
		}

	}
}
