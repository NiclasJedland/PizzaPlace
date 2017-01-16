using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaPlace.Entities;

namespace PizzaPlace.Models
{
    public class Repository 
    {
		private DatabaseContext db;

		public Repository(DatabaseContext _db)
		{
			db = _db;
		}

		public Food Create(Food newFood)
		{


			return newFood;
		}





    }
}
