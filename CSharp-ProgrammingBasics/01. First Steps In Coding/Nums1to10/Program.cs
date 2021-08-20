using System;

namespace Nums1to10
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            int triangleside = num;
            int bothside = num * 2;

            Console.WriteLine(bothside);
        }
    }
}
