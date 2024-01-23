using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(BaseLogger? logger, string message, params object[] arguments)
    {
        if(logger == null)
        {
            throw new ArgumentNullException(nameof(logger) + " logger is null");
        }
        if(arguments == null)
        {
            throw new ArgumentNullException (nameof(arguments) + " arguments is null");
        }
        else
        {
            logger.Log(LogLevel.Error, message + string.Join("", arguments));
        }
    }
    public static void Warning(BaseLogger? logger, string message, params object[] arguments)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger) + " logger is null");
        }
        if (arguments == null)
        {
            throw new ArgumentNullException(nameof(arguments) + " arguments is null");
        }
        else
        {
            logger.Log(LogLevel.Warning, message + string.Join("", arguments));
        }
    }
    public static void Information(BaseLogger? logger, string message, params object[] arguments)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger) + " logger is null");
        }
        if (arguments == null)
        {
            throw new ArgumentNullException(nameof(arguments) + " arguments is null");
        }
        else
        {
            logger.Log(LogLevel.Information, message + string.Join("", arguments));
        }
    }
    public static void Debug(BaseLogger? logger, string message, params object[] arguments)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger) + " logger is null");
        }
        if (arguments == null)
        {
            throw new ArgumentNullException(nameof(arguments) + " arguments is null");
        }
        else
        {
            logger.Log(LogLevel.Debug, message + string.Join("", arguments));
        }
    }

}
