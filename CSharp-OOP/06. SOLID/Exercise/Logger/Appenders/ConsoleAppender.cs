using Logger.Enums;
using Logger.Interfaces;
using System;
using System.Text;

namespace Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }
        public int CounterOfMessages { get; protected set; }
        public void Append(string DateTime, ReportLevel reportLevel, string message)
        {
            if(reportLevel >= this.ReportLevel)
            {
                Console.WriteLine(this.Layout.Format, DateTime, reportLevel, message);
                this.CounterOfMessages++;
            }       
        }

        public string Info()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Appender type: {nameof(ConsoleAppender)}, Layout type: {this.Layout}, Report level: {this.ReportLevel}, " +
                $"Messages appended: {this.CounterOfMessages}");
            return sb.ToString();
        }
    }
}
