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
		[Display(Name = "Ingredient Name:")]
		public string IngredientName { get; set; }

		[Required(ErrorMessage = "Required!")]
		[Range(0, 10000, ErrorMessage = "Cannot be under 0 or above 10000.")]
		[DataType(DataType.Currency)]
		[Display(Name = "Price:")]
		public decimal Price { get; set; }
		public List<FoodIngredient> FoodIngredients { get; set; }
	}
}
