using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathName = Console.ReadLine();
            
            string filenameWithExtention = pathName.Substring(pathName.LastIndexOf((char)92)+1);
            string filename = filenameWithExtention.Split('.')[0];
            string extention = filenameWithExtention.Split('.')[1];
                        
            Console.WriteLine($"File name: {filename}");
            Console.WriteLine($"File extension: {extention}");
        }
    }
}
