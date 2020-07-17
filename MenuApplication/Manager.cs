using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApplication
{
    class Manager
    {
        public List<Cook> Cooks { get; set; }

        public Manager(List<Cook> cooks)
        {
            Cooks = cooks;
        }

        public (bool assigned, TimeSpan cookingTime) Order(Dish dish)
        {
            foreach (var cook in Cooks)
            {
                if (cook.IsAvailable())
                    return (true, cook.Add(dish));
            }

            return (false, TimeSpan.FromSeconds(0));
        }
    }
}
