using System;
using System.Collections.Generic;
using System.Text;

namespace DogShelterExercise
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public Dog()
        {
        }

        public Dog(int id, string name, string color)
        {
            Id = id;
            Name = name;
            Color = color;
        }

        public void Bark()
        {
            Console.WriteLine("WOOF WOOF!!!");
        }

        public static Dog Validate(Dog dog)
        {
            if (dog.Id == 0 && dog.Name == null && dog.Color == null)
            {
                Console.WriteLine("Created Dog instance has no values set for any of its properties.");
            }

            else if (dog.Id < 0 || dog.Name.Length < 3)
            {
                if (dog.Id < 0)
                    Console.WriteLine("Invalid ID of created Dog object.");

                if (dog.Name.Length < 3)
                    Console.WriteLine("Dog name too short.");
            }

            else
            {
                Console.WriteLine($"Dog name: {dog.Name} \n   Dog ID: {dog.Id} \n   Dog color: {dog.Color}");
                Console.WriteLine($"Dog {dog.Name} has all its properties set, and is wiggling it tail and barking happily.");
                dog.Bark();
            }

            return dog;
        }
    }
}
