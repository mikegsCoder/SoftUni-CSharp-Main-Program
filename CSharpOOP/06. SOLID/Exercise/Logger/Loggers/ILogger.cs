namespace Logger.Loggers
{
   public interface ILogger
    {
        void Info(string DateTime, string message);
        void Warning(string DateTime, string message);
        void Error(string DateTime, string message);
        void Critical(string DateTime, string message);
        void Fatal(string DateTime, string message);
    }
}
