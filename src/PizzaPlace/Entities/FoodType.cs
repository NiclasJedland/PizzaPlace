using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Entities
{
    public class FoodType
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "Max 100 characters, at least 1 character")]
		[Display(Name = "Type:")]
		public string Type { get; set; }
		public List<Food> Foods { get; set; }
	}
}
