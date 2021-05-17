using System;
using System.Collections.Generic;
using Task01ClassLibrary;

namespace Task03
{
    class Program
    {

        public static void PrintAllItemsInAList<T>(List<T> list)
        {
            list.ForEach(x => Console.WriteLine(x));
        }

        

        static void Main(string[] args)
        {

            List<int> testList = new List<int>() { 2, 5, 7, 99, 3453 };

            PrintAllItemsInAList(testList);
            Console.ReadLine();
        }
    }
}
