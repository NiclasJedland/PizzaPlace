using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Entities
{
    public class FoodOrder
    {
		public int Id { get; set; }
		public int Quantity { get; set; }
		public Order Order { get; set; }
		public Food Food { get; set; }
	}
}
