namespace PrintNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        private static void PrintEvenNumbers()
        {

            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("Thread EVEN finished work");
        }

        private static void PrintUnevenNumbers()
        {

            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("Thread UNEVEN finished work");
        }
    }
}