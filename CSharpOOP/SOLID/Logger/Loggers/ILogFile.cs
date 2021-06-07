namespace Logger.Loggers
{
   public interface ILogFile
    {
        public long Size { get; }
        public void Write(string message);    
    }
}
