﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private LogLevel logLevel;
        private string message = "No message given ";
        private string className = "No class name given";
        public string filePath = "No file path given";

        public  FileLogger(string filepath)
        {
            this.filePath = filepath;
        }
        public override string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            this.logLevel = logLevel;
            this.message = message;
            StreamWriter sw = File.AppendText(LogToString(logLevel,message,ClassName));
            
        }

        public static string LogToString(LogLevel logLevel, string message, string className)
        {
            string logString = DateTime.Now.ToString("MMM dd yyyy, hh:mm:ss");
            logString = logString + className + logLevel + message;
            return logString;

        }
    }
}
