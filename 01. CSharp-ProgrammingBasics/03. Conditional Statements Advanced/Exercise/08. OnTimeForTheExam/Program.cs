using System;

namespace OnTimeForTheExam_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinute = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMinute;
            int arrivalTime = arrivalHour * 60 + arrivalMinute;

            if (examTime == arrivalTime) Console.WriteLine("On time");
            if (examTime != arrivalTime && examTime - arrivalTime <= 30 && examTime - arrivalTime > 0)
            {
                Console.WriteLine("On time");

                int hh = (examTime - arrivalTime) / 60;
                int mm = (examTime - arrivalTime) % 60;

                Console.WriteLine($"{examTime - arrivalTime} minutes before the start");
            }
            if (examTime != arrivalTime && examTime - arrivalTime > 30)
            {
                Console.WriteLine("Early");

                int hh = (examTime - arrivalTime) / 60;
                int mm = (examTime - arrivalTime) % 60;

                if (hh > 0)
                {
                    if (mm < 10) Console.WriteLine($"{hh}:0{mm} hours before the start");
                    else Console.WriteLine($"{hh}:{mm} hours before the start");
                }

                if (hh == 0) Console.WriteLine($"{mm} minutes before the start");
            }

            if (examTime != arrivalTime && arrivalTime - examTime > 0)
            {
                Console.WriteLine("Late");

                int hh = (arrivalTime - examTime) / 60;
                int mm = (arrivalTime - examTime) % 60;

                if (hh > 0)
                {
                    if (mm < 10) Console.WriteLine($"{hh}:0{mm} hours after the start");
                    else Console.WriteLine($"{hh}:{mm} hours after the start");
                }

                if (hh == 0) Console.WriteLine($"{mm} minutes after the start");
            }
        }
    }
}
