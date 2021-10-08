using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            uint m = uint.Parse(Console.ReadLine());
            uint y = uint.Parse(Console.ReadLine());
            
            double nOrigianl = n;
            uint targetsReached = 0;

            while (n >= m)
            {
                n -= m;
                targetsReached += 1;

                if (n == nOrigianl / 2 && y!=0)
                {
                    n = n / y;
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(targetsReached);
        }
    }
}
