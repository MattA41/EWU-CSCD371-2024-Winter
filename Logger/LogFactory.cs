using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Logger;

public class LogFactory
{
    private string? _filePath;
    public BaseLogger? CreateLogger(string className)
    {
        if (_filePath == null)
        {

            return null;

        }
        else
        {
            return new FileLogger(className);
        }
        
    }
    public void ConfigureFileLogger(string? filePath)
    {
        _filePath = filePath;
    }
}
