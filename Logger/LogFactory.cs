using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Logger;

public class LogFactory
{
    private string? _filePath;
    public BaseLogger CreateLogger(string className)
    {
        if (_filePath == null)
        {
#pragma warning disable CS8603 // Possible null reference return. Project calls for null to be returned if filepath is not set
            return null ;
#pragma warning restore CS8603 // Possible null reference return.
        }
        else
        {
            return new FileLogger(className);
        }
        
    }
    public void ConfigureFileLogger(string filePath)
    {
        _filePath = filePath;
    }
}
