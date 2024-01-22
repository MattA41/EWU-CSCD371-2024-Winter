using System;
using System.Runtime.CompilerServices;

namespace Logger;

public class LogFactory
{
    public BaseLogger CreateLogger(string className)
    {
        string className2 = " ";
        return new FileLogger(className2);
    }
}
