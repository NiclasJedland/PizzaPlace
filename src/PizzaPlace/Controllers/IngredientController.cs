using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Entities;
using PizzaPlace.Models;

namespace PizzaPlace.Controllers
{
	[Authorize(Policy = "AdministratorOnly")]
	public class IngredientController : Controller
	{
		private DatabaseContext db;
		public IngredientController(DatabaseContext _context)
		{
			db = _context;
		}
		public IActionResult Index()
		{
			var vm = ViewModel.GetAllDbItems(db);

			return View(vm);
		}

		[HttpGet]
		public IActionResult Delete(Ingredient ingredient)
		{
			var vm = ViewModel.GetAllDbItems(db);

			var deleted = vm.Ingredients.SingleOrDefault(s => s.Id == ingredient.Id);

			if(deleted.FoodIngredients != null)
			{
				foreach(var item in deleted.FoodIngredients)
				{
					db.FoodIngredients.Remove(item);
				}
			}

			db.Ingredients.Remove(deleted);
			db.SaveChanges();

			return RedirectToAction("Index", "Ingredient");
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			var vm = ViewModel.GetAllDbItems(db);

			vm.Ingredient = vm.Ingredients.SingleOrDefault(s => s.Id == id);

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Ingredient ingredient)
		{
			if(!ModelState.IsValid)
				return View();

			db.Ingredients.Update(ingredient);
			db.SaveChanges();

			return RedirectToAction("Index", "Ingredient");
		}

		[HttpGet]
		public IActionResult Create()
		{
			var vm = ViewModel.GetAllDbItems(db);

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Ingredient ingredient)
		{
			if(!ModelState.IsValid)
				return View();

			db.Ingredients.Add(ingredient);
			db.SaveChanges();

			return RedirectToAction("Index", "Ingredient");
		}

	}
}
