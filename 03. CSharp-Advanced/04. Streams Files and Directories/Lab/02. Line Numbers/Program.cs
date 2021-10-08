using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../input.txt");
            StreamWriter writer = new StreamWriter("../../../output.txt");

            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    int row = 1;

                    while (line != null)
                    {
                        writer.WriteLine($"{row}. {line}");
                        line = reader.ReadLine();
                        row++;
                    }
                }
            }
        }
    }
}
