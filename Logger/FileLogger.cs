using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger(string filepath) : BaseLogger
    {
        public LogLevel LogLevel;
        protected string _message = "No message given";
        private string _className1 = "No class name given";
        public string _filePath = filepath;

        public override string ClassName
        {
            get { return _className1; }
            set { _className1 = value; }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            this.LogLevel = logLevel;
            this._message = message;
            File.AppendText(LogToString(logLevel, message, ClassName));

        }

        public static string LogToString(LogLevel logLevel, string message, string className)
        {
            string logString = DateTime.Now.ToString("MMM dd yyyy, hh:mm:ss", new CultureInfo("en-US"));
            logString = logString + className + logLevel + message;
            return logString;

        }
    }
}
