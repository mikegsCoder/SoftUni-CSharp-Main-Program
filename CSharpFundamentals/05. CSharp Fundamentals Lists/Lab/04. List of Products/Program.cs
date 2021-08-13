using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> listOfProducts = new List<string>();

            for (int i = 0; i < n; i++)
            {
                listOfProducts.Add(Console.ReadLine());
            }

            SortListOfProducts(listOfProducts);
        }

        static void SortListOfProducts(List<string> ListOfProducts)
        {
            ListOfProducts.Sort();

            for (int i = 0; i < ListOfProducts.Count; i++)
            {
                Console.WriteLine($"{i+1}.{ListOfProducts[i]}");
            }
        }
    }
}
