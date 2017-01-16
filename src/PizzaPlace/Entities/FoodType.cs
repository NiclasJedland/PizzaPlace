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
		public string Type { get; set; }
		public List<Food> Foods { get; set; }
	}
}
