using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.Entities;

namespace PizzaPlace.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private DatabaseContext db;
		public AccountController(DatabaseContext _context)
		{
			db = _context;
		}

		const string claimLoginCookie = "LoginCookie";
		const string claimCustomerId = "CustomerId";
		const string claimAccountName = "AccountName";
		const string claimPassword = "Password";
		const string claimRegularUser = "RegularUser";
		const string claimMember = "Member";

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(Customer customer)
		{
			var tempCustomer = db.Customers.Include(s => s.Role)
				.SingleOrDefault(s => s.AccountName == customer.AccountName
				&& s.Password == customer.Password);

			if(tempCustomer == null)
				return View();

			var claims = new List<Claim>() {
				new Claim(claimCustomerId, tempCustomer.Id.ToString(), ClaimValueTypes.Integer32),
				new Claim(claimAccountName, tempCustomer.AccountName, ClaimValueTypes.String),
				new Claim(claimPassword, tempCustomer.Password, ClaimValueTypes.String),
				new Claim(claimMember, tempCustomer.Role.UserRole.ToString(), ClaimValueTypes.String)
			};

			var userIdentity = new ClaimsIdentity(claims, tempCustomer.Role.UserRole.ToString());
			var userPrincipal = new ClaimsPrincipal(userIdentity);

			await HttpContext.Authentication.SignInAsync(claimLoginCookie, userPrincipal,
				new AuthenticationProperties
				{
					ExpiresUtc = DateTime.UtcNow.AddMinutes(60), //default 20 min
					IsPersistent = true,
					AllowRefresh = true
			});

			//return RedirectToLocal(returnUrl);
			return RedirectToAction("Index", "Home");
		}
		
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(Customer customer)
		{
			if(!ModelState.IsValid)
				return RedirectToAction("Register");

			customer.Role = db.Roles.FirstOrDefault(s => s.UserRole == UserRole.RegularUser);

			db.Customers.Add(customer);
			db.SaveChanges();

			customer.Id = db.Customers.SingleOrDefault(s => s == customer).Id;

			var claims = new List<Claim> {
				new Claim(claimCustomerId, customer.Id.ToString(), ClaimValueTypes.Integer32),
				new Claim(claimAccountName, customer.AccountName, ClaimValueTypes.String),
				new Claim(claimPassword, customer.Password, ClaimValueTypes.String),
				new Claim(claimMember, claimRegularUser, ClaimValueTypes.String)
			};

			var userIdentity = new ClaimsIdentity(claims, claimRegularUser);
			var userPrincipal = new ClaimsPrincipal(userIdentity);

			await HttpContext.Authentication.SignInAsync(claimLoginCookie, userPrincipal,
				new AuthenticationProperties
				{
					ExpiresUtc = DateTime.UtcNow.AddMinutes(60), //default 20 min
					IsPersistent = true,
					AllowRefresh = true
				});
			
			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.Authentication.SignOutAsync(claimLoginCookie);
			return RedirectToAction("Index", "Home");
		}
	}
}
