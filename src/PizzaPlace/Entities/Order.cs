using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Entities
{
    public class Order
    {
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }

		[DataType(DataType.Currency)]
		public decimal Cost { get; set; }
		public Customer Customer { get; set; }
	}
}
