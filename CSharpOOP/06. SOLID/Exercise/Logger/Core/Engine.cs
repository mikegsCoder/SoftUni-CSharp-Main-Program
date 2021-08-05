using System;
using System.Collections.Generic;
using Logger.Appenders;
using Logger.Enums;
using Logger.Factory;
using Logger.Interfaces;
using Logger.Loggers;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IAppender> listOfAppenders = new List<IAppender>();
            int numberOfAppenders = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string appenderType = input[0];
                string layoutType =  input[1];
                ILayout layout = LayoutCreator.Create(layoutType);

                if (input.Length == 2)
                {                
                    IAppender appender = AppenderCreator.Create(appenderType, layout);
                    appender.ReportLevel = ReportLevel.INFO;
                    listOfAppenders.Add(appender);
                }

                else if(input.Length == 3)
                {
                    ReportLevel reportLevel = Enum.Parse<ReportLevel>(input[2].ToUpper(), false);
                    IAppender appender = AppenderCreator.Create(appenderType, layout);
                    appender.ReportLevel = reportLevel;
                    listOfAppenders.Add(appender);
                }                   
            }

            ILogger logger = new Loggers.Logger(listOfAppenders.ToArray());
            string command;
            while ((command = Console.ReadLine()) != "END")
            {              
                string[] commandArguments = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                ReportLevel reportLevel = Enum.Parse<ReportLevel>(commandArguments[0], false);
                string dateTime = commandArguments[1];
                string message = commandArguments[2];

                switch (reportLevel)
                {
                    case ReportLevel.INFO:
                        logger.Info(dateTime, message);
                        break;
                    case ReportLevel.WARNING:
                        logger.Warning(dateTime, message);
                        break;
                    case ReportLevel.ERROR:
                        logger.Error(dateTime, message);
                        break;
                    case ReportLevel.CRITICAL:
                        logger.Critical(dateTime, message);
                        break;
                    case ReportLevel.FATAL:
                        logger.Fatal(dateTime, message);
                        break;
                }
            }

            Console.WriteLine("Logger info");
            foreach (var apppender in listOfAppenders)
            {
                Console.WriteLine(apppender.Info());
            }
        }
    }
}
