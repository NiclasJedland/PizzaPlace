using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaPlace.Entities;

namespace PizzaPlace.Models
{
    public class Cart
    {
		public Dictionary<Food, int> Food { get; set; }
		public decimal TotalCost { get; set; }

		public void AddToCart(Food food)
		{

		}
	}
}
