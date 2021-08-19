using System;

namespace TemplatePattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SourDoughBread sourDoughBread = new SourDoughBread();
            sourDoughBread.Make();

            WholeGrainBread wholeGrainBread = new WholeGrainBread();
            wholeGrainBread.Make();
        }
    }
}
