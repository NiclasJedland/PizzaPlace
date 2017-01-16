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
		public string IngredientName { get; set; }

		[DataType(DataType.Currency)]
		public decimal Price { get; set; }
		public List<FoodIngredient> FoodIngredients { get; set; }
	}
}
