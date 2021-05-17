using System;
using System.Collections.Generic;
using System.Text;

namespace Task01ClassLibrary
{
    public class Cat : Animal
    {
        public bool IsLazy { get; set; }

        public Cat()
        {
        }
        public Cat(string name, int age, string color, bool isLazy) : base(name, age, color)
        {
            IsLazy = isLazy;
        }
        public void Meow()
        {
            Console.WriteLine("MEEEEOOOOW!");
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"I am {Name} the cat.");
            Console.WriteLine(IsLazy ? "I am a very lazy cat." : "I am not a lazy kitty.");
            Console.WriteLine($"I am {Age} years old.");
            Console.WriteLine($"My fur is {Color}.");
            Meow();
        }
    }
}
