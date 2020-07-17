using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace MenuApplication
{
    class Cook
    {
        public string Name { get; set; }
        public TimeSpan CookingTimeOfLastDish { get; set; }

        private Queue<Dish> dishQueue = new Queue<Dish>(5);

        public Cook(string name)
        {
            Name = name;
        }

        public bool IsAvailable()
        {
            return dishQueue.Count < 5;
        }

        public TimeSpan Add(Dish dish)
        {
            if (dishQueue.Count == 5)
                throw new ArgumentOutOfRangeException("cook is full");

            dishQueue.Enqueue(dish);
            CookingTimeOfLastDish += dish.CookingTime;

            return CookingTimeOfLastDish;
        }
    }
}
