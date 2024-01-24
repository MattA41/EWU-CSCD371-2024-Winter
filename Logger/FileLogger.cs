using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Logger;
    public class FileLogger(string filepath) : BaseLogger
    {
        private LogLevel _logLevel;
        private string _message = "No message given";
        private string _className1 = "No class name given";
        private string _filePath = filepath;

        public override string ClassName
        {
            get { return _className1; }
            set { _className1 = value; }
        }

        public string FilePath { get => _filePath; set => _filePath = value; }
        public string Message { get => _message; set => _message = value; }
        public LogLevel LogLevel1 { get => _logLevel; set => _logLevel = value; }

        public override void Log(LogLevel logLevel, string message)
        {
            this._logLevel = logLevel;
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

