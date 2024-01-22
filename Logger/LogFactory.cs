namespace Logger;

public class LogFactory :BaseLogger
{
    public BaseLogger CreateLogger(string className)
    {
        this.className = className;
        return null;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        throw new System.NotImplementedException();
    }

}
