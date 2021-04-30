using System;
using System.Collections.Generic;
using System.Text;

namespace DogShelterExercise
{
    public static class DogShelter
    {
        public static List<Dog> Dogs { get; set; }

        static DogShelter()
        {
            Dogs = new List<Dog>()
            {
                new Dog(),
                new Dog(0, null, null),
                new Dog(-1, "Dzeki", "brown"),
                new Dog(3, "Ps", "black"),
                new Dog(2, "Murdzo", null),
                new Dog(2, "P", ""),
                new Dog(0, "Sharko", "white"),
                new Dog(5, "Aldo", "brown")
            };
        }
        public static void PrintAll()
        {
            for (int i = 1; i <= Dogs.Count; i++)
            {
                Console.Write($"{i}. ");
                Dog.Validate(Dogs[i - 1]);
                Console.WriteLine("\n-----------------------------------------------------------------------------------\n");

            }
        }
    }
}