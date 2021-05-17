using System;
using System.Collections.Generic;
using Task01ClassLibrary;
using System.Linq;

namespace Task01
{
    class Program
    {
        public static void PrintAllAnimals<T>(List<T> listOfAnimals) where T : Animal
        {
            listOfAnimals.ForEach(x => x.PrintInfo());
        }

        static void Main(string[] args)
        {
            try
            {
                List<Dog> allDogs = new List<Dog>
                {
                    new Dog("Pero", 5, "grey", "poodle"),
                    new Dog("Blazo", 3, "white", "pit bull"),
                    new Dog("Mile", 2, "black and brown", "german shepperd")
                };

                List<Cat> allCats = new List<Cat>
                {
                    new Cat("Lucifer", 1, "black and white", true),
                    new Cat("Garfield", 1, "orange", true),
                    new Cat("Crookshanks", 2, "orange", false)
                };

                List<Bird> allBirds = new List<Bird>
                {
                    new Bird("Hedwig", 2, "white", false),
                    new Bird("Roadrunner", 8, "blue", true),
                    new Bird("Mickey", 1, "black", true)
                };



                List<Dog> allPitBulls = allDogs
                                .Where(x => x.Breed == "pit bull")
                                .ToList();
                Console.WriteLine("\n----------------------------------------------------------------------\n");
                Console.WriteLine("Let all the pit bulls introduce themselves to you :) Here they go:");
                allPitBulls.ForEach(x => x.PrintInfo());

                Cat lastLazyCat = allCats
                               .LastOrDefault(x => x.IsLazy);

                Console.WriteLine("\n----------------------------------------------------------------------\n");
                Console.WriteLine("Here's the last lazy cat: P");
                lastLazyCat.PrintInfo();


                List<Bird> wildBirdsYoungerThan3OrderedByName = allBirds
                                    .Where(x => x.Age < 3 && x.IsWild)
                                    .OrderBy(x => x.Name)
                                    .ToList();

                Console.WriteLine("\n----------------------------------------------------------------------\n");
                Console.WriteLine("Here are all the wild birds younger than 3, ordered by name:");
                wildBirdsYoungerThan3OrderedByName.ForEach(x => x.PrintInfo());
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }    
    }
}
