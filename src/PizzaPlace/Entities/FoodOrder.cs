using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Entities
{
    public class FoodOrder
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Required!")]
		[Range(0, 1000, ErrorMessage = "Cannot be under 0 or above 1000.")]
		public int Quantity { get; set; }
		public Order Order { get; set; }
		public Food Food { get; set; }
	}
}
