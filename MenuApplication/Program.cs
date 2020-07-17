using System;
using System.Collections.Generic;

namespace MenuApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dish> menu = GetMenu();
            var manager = CreatePizzaManager();

            string order = "";
            while (order != "exit")
            {
                if (!string.IsNullOrWhiteSpace(order))
                {
                    menu.TryGetValue(order, out Dish dish);
                    if (dish != null)
                    {
                        (bool assigned, TimeSpan time) = manager.Order(dish);
                        if (!assigned)
                            Console.WriteLine("No cooks available");
                        else
                            Console.WriteLine($"The Dish will be done in {time.Minutes} min");
                    }
                    else
                    {
                        Console.WriteLine("dish not found");
                    }
                }
                foreach (var item in menu)
                {
                    var dish = item.Value;
                    Console.WriteLine($"{dish.Name} Price: {dish.GetPrice()}; Description: {dish.Description}");
                    dish.Ingredients.ForEach(x => Console.WriteLine($" Ingredients: {x.Name}"));
                }
                Console.WriteLine(new String('-',35));
                Console.WriteLine("Enter name of dish you wish or exit");
                order = Console.ReadLine();
            }
        }

        private static Manager CreatePizzaManager()
        {
            return new Manager(new List<Cook> { new Cook("A.Sebastian"), new Cook("M.Pepperoni") });
        }
        private static Dictionary<string, Dish> GetMenu()
        {
            string margaritaDescription = " typical Neapolitan pizza, made with San Marzano tomatoes, mozzarella cheese, fresh basil, salt and extra-virgin olive oil.";
            string quattroFormaggiDescription = " is a variety of pizza in Italian cuisine that is topped with a combination of four kinds of cheese, usually melted together, with (red) or without (white) tomato sauce.";
            string calzoneDescription = "The dough is then folded in half over the filling and sealed with an egg mixture in a half-moon shape, or is sometimes shaped into a ball by pinching and sealing all the edges at the top";

            var dishes = new Dictionary<string, Dish>();
            dishes.Add("PizzaMargarita",
                new Dish(
                    "Pizza Margarita.", margaritaDescription, TimeSpan.FromMinutes(10),
                    new List<Ingredient> { new Ingredient("dough", 1.2m),
                                           new Ingredient("san marzano tomatoes",0.4m),
                                           new Ingredient("mozzarella",0.7m)}));
            dishes.Add("PizzaQuattroFormaggi",
                new Dish(
                    "Pizza QuattroFormaggi.", quattroFormaggiDescription, TimeSpan.FromMinutes(8),
                    new List<Ingredient> { new Ingredient("mozzarella",0.7m),
                                           new Ingredient("gorgonzola",1.4m),
                                           new Ingredient("fontina",1.1m),
                                           new Ingredient("parmigiano",0.8m)}));
            dishes.Add("PizzaCalzone",
                new Dish(
                    "Pizza Calzone.", calzoneDescription, TimeSpan.FromMinutes(12),
                    new List<Ingredient> { new Ingredient("ricotta",0.3m),
                                           new Ingredient("salami",0.5m),
                                           new Ingredient("pecorino",0.4m) }));


            return dishes;
        }
    }
}
