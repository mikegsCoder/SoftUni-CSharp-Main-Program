using Logger.Appenders;
using Logger.Interfaces;
using Logger.Loggers;
using System;

namespace Logger.Factory
{
   public static class AppenderCreator
    {
        public static IAppender Create(string type, ILayout layout)
        {          
            IAppender appender = null;
            switch (type)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout);
                    break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout, new LogFile());
                    break;
                default:
                    throw new ArgumentException("Invalid Appender type!");
            }

            return appender;
        }
    }
}
