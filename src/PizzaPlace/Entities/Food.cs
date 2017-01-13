using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Entities
{
    public class Food
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Max 50 characters, at least 2 characters")]
		public string Name { get; set; }

		[StringLength(maximumLength: 250, MinimumLength = 1, ErrorMessage = "Max 250 characters, at least 1 character")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Required!")]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Required!")]
		public FoodType Type { get; set; }

		public ICollection<FoodIngredient> FoodIngredients { get; set; }
	}
}
