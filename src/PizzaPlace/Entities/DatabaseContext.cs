using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PizzaPlace.Entities
{
    public class DatabaseContext : DbContext
    {
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		public DbSet<Food> Foods { get; set; }
		public DbSet<FoodIngredient> FoodIngredients { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<FoodType> FoodTypes { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<FoodOrder> FoodOrders { get; set; }
		public DbSet<Role> Roles { get; set; }
	}
}
