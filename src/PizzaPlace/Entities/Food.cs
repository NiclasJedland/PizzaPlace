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
		[StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Max 50 characters, at least 1 character")]
		[Display(Name = "Food name:")]
		public string Name { get; set; }

		[StringLength(maximumLength: 2000, ErrorMessage = "Max 2000 characters")]
		[Display(Name = "Description:")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Required!")]
		[DataType(DataType.Currency)]
		[Range(0, 10000, ErrorMessage = "Cannot be under 0 or above 10000.")]
		[Display(Name = "Price:")]
		public decimal Price { get; set; }
		public FoodType FoodType { get; set; }
		public List<FoodIngredient> FoodIngredients { get; set; }
	}
}
