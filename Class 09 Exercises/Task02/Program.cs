using System;
using System.Collections.Generic;
using Task02ClassLibrary;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> testList = new List<int>() { 2, 5, 7, 99, 3453 };


            Console.WriteLine(Task02StaticClassForExtensionMethods.GetFirstLetter("bla"));
            Console.WriteLine(Task02StaticClassForExtensionMethods.GetLastLetter("bla"));
            Console.WriteLine(Task02StaticClassForExtensionMethods.CheckIfEven(9));
            Console.WriteLine(Task02StaticClassForExtensionMethods.CheckIfEven(6));
            Task02StaticClassForExtensionMethods.GetNFirst(testList, 3);

            Console.ReadLine();
        }
    }
}
