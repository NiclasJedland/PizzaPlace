using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Entities
{
	public enum UserRole
	{
		RegularUser, PremiumUser, Admin
	}
    public class Role
    {
		public int Id { get; set; }
		public double Discount { get; set; }
		public UserRole UserRole { get; set; }
		public List<Customer> Customers { get; set; }
	}
}
