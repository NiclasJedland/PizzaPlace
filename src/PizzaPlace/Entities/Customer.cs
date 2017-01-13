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
		[StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Max 50 characters, at least 3 character")]
		public string AccountName { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Max 50 characters, at least 1 character")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Max 50 characters, at least 1 character")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 1000, MinimumLength = 5, ErrorMessage = "Max 1000 characters, at least 5 character")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 250, MinimumLength = 5, ErrorMessage = "Max 250 characters, at least 5 character")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Max 20 characters, at least 5 character")]
		public string Zip { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Max 50 characters, at least 1 character")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Max 50 characters, at least 1 character")]
		public string Phone { get; set; }

	}
}
