using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Entities
{
    public class Customer
    {
		public int Id { get; set; }
		public string AccountName { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string Zip { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public List<Order> Orders { get; set; }
	}
}
