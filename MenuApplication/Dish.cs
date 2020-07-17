using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApplication
{
    class Dish
    {
        public string Name { get; set; }
        public string Description { get;  set; }
        public TimeSpan CookingTime { get;  set; }
        public List<Ingredient> Ingredients { get; set; }

        public Dish(string name, string description, TimeSpan cooking_time,  List<Ingredient> ingredients)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            CookingTime = cooking_time;
        }

        public decimal GetPrice()
        {
            decimal price = 0;
            foreach (var item in Ingredients)
            {
                price += (item.Price) * 1.2m;
            }
            return price;
        }
    }
}
