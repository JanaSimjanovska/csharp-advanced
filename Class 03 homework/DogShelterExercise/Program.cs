using System;
using System.Collections.Generic;

namespace DogShelterExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog toto = new Dog(3, "Toto", "white");
            Dog emptyDoggoObj = new Dog();
            Dog shortNameDoggo = new Dog(4, "P", "black");
            Dog badIdDoggo = new Dog(-2, "Cookie", "brown");

            DogShelter.Dogs.AddRange(new List<Dog>() { toto, emptyDoggoObj, shortNameDoggo, badIdDoggo });

            DogShelter.PrintAll();

            Console.ReadLine();
        }
    }
}
