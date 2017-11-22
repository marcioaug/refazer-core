using System.IO;

namespace Tutor
{
    public class Logger
    {
        public static Logger Instance { get;  } = new Logger();

        private string _logFile = "log.txt"; 
        public void Log(string message)
        {
            File.AppendAllText(_logFile, message);
        }
    }
}
