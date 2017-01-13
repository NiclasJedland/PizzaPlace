using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Entities
{
    public class Ingredient
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Required!")]
		[StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Max 50 characters, at least 1 character")]
		public string IngredientName { get; set; }

		[Required(ErrorMessage = "Required!")]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		public ICollection<FoodIngredient> FoodIngredients { get; set; }
	}
}
