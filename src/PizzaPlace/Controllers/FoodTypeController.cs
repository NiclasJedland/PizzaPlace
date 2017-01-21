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
		public IActionResult Delete(Customer customer)
		{
			var vm = ViewModel.GetAllDbItems(db);

			var deleted = vm.Customers.SingleOrDefault(s => s.Id == customer.Id);

			db.Customers.Remove(deleted);
			db.SaveChanges();

			return RedirectToAction("Index", "Customer");
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			var vm = ViewModel.GetAllDbItems(db);

			vm.Customer = vm.Customers.SingleOrDefault(s => s.Id == id);

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Customer customer, Role role)
		{
			if(!ModelState.IsValid)
				return View();

			var vm = ViewModel.GetAllRoles(db);

			var getRole = vm.Roles.FirstOrDefault(s => s.UserRole == role.UserRole);
			customer.Role = getRole;

			db.Customers.Update(customer);
			db.SaveChanges();

			return RedirectToAction("Index", "Customer");
		}

		[HttpGet]
		public IActionResult Create()
		{
			var vm = ViewModel.GetAllDbItems(db);
			vm.Customer = new Customer();
			vm.Role = new Role();
			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Customer customer, Role role)
		{
			if(!ModelState.IsValid)
				return View();

			var vm = ViewModel.GetAllDbItems(db);
			var getRole = vm.Roles.FirstOrDefault(s => s.UserRole == role.UserRole);
			customer.Role = getRole;

			db.Customers.Add(customer);
			db.SaveChanges();

			return RedirectToAction("Index", "Customer");
		}
	}

}
