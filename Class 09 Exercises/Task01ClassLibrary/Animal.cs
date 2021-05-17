using System;
using System.Collections.Generic;
using System.Text;

namespace Task01ClassLibrary
{
    public abstract class Animal
    {
        public string Name { get; set; }

        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > 175 || value < 0)
                {
                    throw new Exception();
                }
                _age = value;
            }
        }

        public Animal()
        {
        }

        public Animal(string name, int age, string color)
        {
            Name = name;
            Age = age;
            Color = color;
        } 

        public string Color { get; set; }


        public abstract void PrintInfo();
    }
}
