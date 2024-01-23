using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Logger;

public class LogFactory
{
    private string? _filePath;
    public BaseLogger? CreateLogger(string className)
    {
        return _filePath == null ? null : (BaseLogger)new FileLogger(className);

    }
    public void ConfigureFileLogger(string? filePath)
    {
        _filePath = filePath;
    }
}
