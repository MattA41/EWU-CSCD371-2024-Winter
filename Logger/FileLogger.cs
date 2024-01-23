using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger(string filepath) : BaseLogger
    {
        public LogLevel LogLevel;
        public string Message = "No message given ";
        public string ClassName1 = "No class name given";
        public string FilePath = filepath;

        public override string ClassName
        {
            get { return ClassName1; }
            set { ClassName1 = value; }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            this.LogLevel = logLevel;
            this.Message = message;
            File.AppendText(LogToString(logLevel, message, ClassName));

        }

        public static string LogToString(LogLevel logLevel, string message, string className)
        {
            string logString = DateTime.Now.ToString("MMM dd yyyy, hh:mm:ss");
            logString = logString + className + logLevel + message;
            return logString;

        }
    }
}
