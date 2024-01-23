using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? logger, string message, params object[] arguments)
    {
        ArgumentNullException.ThrowIfNull(logger);
        logger.Log(LogLevel.Error, message + string.Join(" ", arguments));
    }
    public static void Warning(this BaseLogger? logger, string message, params object[] arguments)
    {
        ArgumentNullException.ThrowIfNull(logger);
        logger.Log(LogLevel.Warning, message + string.Join(" ", arguments));
    }
    public static void Information(this BaseLogger? logger, string message, params object[] arguments)
    {
        ArgumentNullException.ThrowIfNull(logger);
        logger.Log(LogLevel.Information, message + string.Join(" ", arguments));
    }
    public static void Debug(this BaseLogger? logger, string message, params object[] arguments)
    {
        ArgumentNullException.ThrowIfNull(logger);
        logger.Log(LogLevel.Debug, message + string.Join(" ", arguments));
    }

}
