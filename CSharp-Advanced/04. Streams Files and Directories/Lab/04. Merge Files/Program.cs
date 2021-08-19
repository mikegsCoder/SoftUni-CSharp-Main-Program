using System.IO;

namespace _04._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader readerOne = new StreamReader("../../../FileOne.txt");
            StreamReader readerTwo = new StreamReader("../../../FileTwo.txt");
            StreamWriter writer = new StreamWriter("../../../output.txt");

            using (readerOne)
            {
                using (readerTwo)
                {
                    using (writer)
                    {
                        string lineOne = readerOne.ReadLine();
                        string lineTwo = readerTwo.ReadLine();

                        while (lineOne != null && lineTwo != null)
                        {
                            writer.WriteLine(lineOne);
                            writer.WriteLine(lineTwo);

                            lineOne = readerOne.ReadLine();
                            lineTwo = readerTwo.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
