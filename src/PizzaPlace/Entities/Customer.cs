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

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Max 50 characters, at least 5 character")]
		[Display(Name = "Account name:")]
		public string AccountName { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 8, ErrorMessage = "Max 50 characters, at least 8 character")]
		[Display(Name = "Password:")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Max 50 characters, at least 2 character")]
		[Display(Name = "First name:")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Max 50 characters, at least 2 character")]
		[Display(Name = "Last name:")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Max 50 characters, at least 1 character")]
		[Display(Name = "Address:")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 1)]
		[Display(Name = "Zip code:")]
		public string Zip { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 1)]
		[Display(Name = "City:")]
		public string City { get; set; }

		[DataType(DataType.EmailAddress)]
		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 8)]
		[Display(Name = "Email:")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 5)]
		[Display(Name = "Phone number:")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Required!")]
		[Display(Name = "Premium coins:")]
		[Range(0, 500, ErrorMessage = "Cannot be under 0 or above 500.")]
		public int PremiumCoins { get; set; }

		[Display(Name = "Role:")]
		public Role Role { get; set; }
		public List<CartItem> CartItems { get; set; }
		public List<Order> Orders { get; set; }
	}
}
