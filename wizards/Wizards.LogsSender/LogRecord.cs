namespace Wizards.LogsSender
{
    public class LogRecord
    {
        public DateTime TimeStamp { get; set; }
        public string AppName { get; set; }
        public string LogLevel { get; set; }
        public string LogMessage { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}