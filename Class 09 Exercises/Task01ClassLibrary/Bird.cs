using System;
using System.Collections.Generic;
using System.Text;

namespace Task01ClassLibrary
{
    public class Bird : Animal
    {
        public bool IsWild { get; set; }
        public Bird()
        {
        }
        public Bird(string name, int age, string color, bool isWild) : base(name, age, color)
        {
            IsWild = isWild;
        }
        public void FlySouth()
        {
            Console.WriteLine(IsWild ? "I am a wild thing and I fly south" : "I like it at home :)");
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"I am {Name} the bird.");
            Console.WriteLine($"I am {Age} years old.");
            Console.WriteLine($"My feathers' color is {Color}.");
        }
    }
}
