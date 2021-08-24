using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {            
            double ammount = double.Parse(Console.ReadLine());
            ammount = ammount * 100;

            double count1 = 0;
            double count2 = 0;
            double count3 = 0;
            double count4 = 0;
            double count5 = 0;
            double count6 = 0;
            double count7 = 0;
            double count8 = 0;
            double counter = 0;

            if (ammount / 200 >= 1 )
            {
                count8 = Math.Floor(ammount / 200);
                ammount = ammount - count8 * 200;
            }

            if (ammount / 100 >= 1)
            {
                count7 = Math.Floor(ammount / 100);
                ammount = ammount - count7 * 100;
            }

            if (ammount / 50 >= 1)
            {
                count6 = Math.Floor(ammount / 50);
                ammount = ammount - count6 * 50;
            }

            if (ammount / 20 >= 1)
            {
                count5 = Math.Floor(ammount / 20);
                ammount = ammount - count5 * 20;
            }

            if (ammount / 10 >= 1)
            {
                count4 = Math.Floor(ammount / 10);
                ammount = ammount - count4 * 10;
            }

            if (ammount / 5 >= 1)
            {
                count3 = Math.Floor(ammount / 5);
                ammount = ammount - count3 * 5;
            }

            if (ammount / 2 >= 1)
            {
                count2 = Math.Floor(ammount / 2);
                ammount = ammount - count2 * 2;
            }

            if (ammount / 1 >= 1)
            {
                count1 = Math.Floor(ammount / 1);
                ammount = ammount - count1 * 1;
            }

            counter = count1 + count2 + count3 + count4 + count5 + count6 + count7 + count8;

            Console.WriteLine(counter);
        }
    }
}
