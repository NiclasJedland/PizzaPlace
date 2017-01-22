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
	public class FoodTypeController : Controller
	{
		private DatabaseContext db;
		public FoodTypeController(DatabaseContext _context)
		{
			db = _context;
		}
		public IActionResult Index()
		{
			var vm = ViewModel.GetAllDbItems(db);

			return View(vm);
		}

		[HttpGet]
		public IActionResult Delete(FoodType foodType)
		{
			var vm = ViewModel.GetAllDbItems(db);

			var deleted = vm.FoodTypes.SingleOrDefault(s => s.Id == foodType.Id);

			if(deleted.Foods != null)
			{
				foreach(var item in deleted.Foods)
				{
					item.FoodType = db.FoodTypes.SingleOrDefault(s => s.Type == "Other");
				}
			}

			db.FoodTypes.Remove(deleted);
			db.SaveChanges();

			return RedirectToAction("Index", "FoodType");
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			var vm = ViewModel.GetAllDbItems(db);

			vm.FoodType = vm.FoodTypes.SingleOrDefault(s => s.Id == id);

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(FoodType foodType)
		{
			if(!ModelState.IsValid)
				return View();

			db.FoodTypes.Update(foodType);
			db.SaveChanges();

			return RedirectToAction("Index", "FoodType");
		}

		[HttpGet]
		public IActionResult Create()
		{
			var vm = ViewModel.GetAllDbItems(db);

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(FoodType foodType)
		{
			if(!ModelState.IsValid)
				return View();

			db.FoodTypes.Add(foodType);
			db.SaveChanges();

			return RedirectToAction("Index", "FoodType");
		}
	}

}
