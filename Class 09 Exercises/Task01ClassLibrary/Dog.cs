using System;
using System.Collections.Generic;
using System.Text;

namespace Task01ClassLibrary
{
    public class Dog : Animal
    {
        public string Breed { get; set; }

        public Dog()
        {
        }
        public Dog(string name, int age, string color, string breed) : base(name, age, color)
        {
            Breed = breed;
        }

        public void Bark()
        {
            Console.WriteLine("WOOF WOOF!");
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"I am {Name} the dog.");
            Console.WriteLine($"I am a {Breed}.");
            Console.WriteLine($"I am {Age} years old.");
            Console.WriteLine($"My fur is {Color}.");
            Bark();
        }
    }
}
