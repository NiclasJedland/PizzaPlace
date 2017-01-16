﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Entities
{
    public class Food
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		[DataType(DataType.Currency)]
		public decimal Price { get; set; }
		public FoodType FoodType { get; set; }
		public List<FoodIngredient> FoodIngredients { get; set; }
	}
}
