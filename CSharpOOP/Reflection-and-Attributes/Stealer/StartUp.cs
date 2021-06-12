using System;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // P01 Stealer
            //Spy spy = new Spy();
            //string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            //Console.WriteLine(result);

            // P02 High Quality Mistakes
            //Spy spy = new Spy();
            //string result = spy.AnalyzeAcessModifiers("Stealer.Hacker");
            //Console.WriteLine(result);

            // P03 Mission Private Impossible
            //Spy spy = new Spy();
            //string result = spy.RevealPrivateMethods("Stealer.Hacker");
            //Console.WriteLine(result);

            // P04 Collector
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
