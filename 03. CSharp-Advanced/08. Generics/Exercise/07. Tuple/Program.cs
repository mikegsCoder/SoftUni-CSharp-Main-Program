using System;

namespace P07Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Tuple<int, double, string> tuple = new Tuple<int, double, string>(10, 5.5, "Peter");
            //Console.WriteLine(tuple.Item1);
            //Console.WriteLine(tuple.Item2);
            //Console.WriteLine(tuple.Item3);

            //(int, string) t1 = (20, "Gosho");
            //Console.WriteLine(t1.Item1);
            //Console.WriteLine(t1.Item2);

            //(int num, string name) t2 = (30, "George");
            //Console.WriteLine(t2.num);
            //Console.WriteLine(t2.name);

            string[] tupleData = Console.ReadLine().Split();
            MyTuple<string, string> firstTuple =
                new MyTuple<string, string>($"{tupleData[0]} {tupleData[1]}", tupleData[2]);

            tupleData = Console.ReadLine().Split();
            MyTuple<string, int> secondTuple =
                new MyTuple<string, int>(tupleData[0], int.Parse(tupleData[1]));

            tupleData = Console.ReadLine().Split();
            MyTuple<int, double> thirdTuple =
                new MyTuple<int, double>(int.Parse(tupleData[0]), double.Parse(tupleData[1]));

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
