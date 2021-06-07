using System;
using System.IO;
using System.Linq;

namespace Logger.Loggers
{
    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";
       
        long ILogFile.Size => File.ReadAllText(LogFilePath).Where(ch=>char.IsLetter(ch)).Sum(ch=>ch);

        public void Write(string message)
        {
            File.AppendAllText(LogFilePath, message + Environment.NewLine);
        }
    }
}
