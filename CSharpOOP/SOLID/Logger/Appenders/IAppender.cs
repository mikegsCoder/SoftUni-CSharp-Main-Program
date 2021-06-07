using Logger.Enums;
using Logger.Interfaces;

namespace Logger.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        public int CounterOfMessages { get; }
        public void Append(string DateTime, ReportLevel LogLevel, string message);
        public string Info();
    }
}
