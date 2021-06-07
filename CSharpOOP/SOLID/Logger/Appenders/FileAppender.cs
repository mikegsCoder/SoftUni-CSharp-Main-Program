using Logger.Enums;
using Logger.Interfaces;
using Logger.Loggers;
using System.Text;

namespace Logger.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile LogFile)
        {
            this.Layout = layout;
            this.LogFile = LogFile;
        }
        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }
        public ILogFile LogFile { get; }
        public int CounterOfMessages { get; protected set; }

        public void Append(string DateTime, ReportLevel LogLevel, string message)
        {
            string formatedMessage = string.Format(this.Layout.Format, DateTime, LogLevel, message);
            this.LogFile.Write(formatedMessage);
            this.CounterOfMessages++;
        }

        public string Info()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Appender type: {nameof(FileAppender)}, Layout type: {this.Layout}, Report level: " +
                $"{this.ReportLevel}, " +
                $"Messages appended: {this.CounterOfMessages}, File size: {this.LogFile.Size}");
            return sb.ToString();
        }
    }
}
