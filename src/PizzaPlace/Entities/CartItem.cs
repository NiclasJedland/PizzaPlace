using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Entities
{
    public class CartItem
    {
		public int Id { get; set; }

		[Display(Name = "Date created:")]
		public DateTime DateCreated { get; set; }
		public Customer Customer { get; set; }
		public Food Food { get; set; }
	}
}
