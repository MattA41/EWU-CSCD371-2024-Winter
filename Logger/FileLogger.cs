namespace Logger;

public class FileLogger(string logSource, string filePath) : BaseLogger(logSource), ILogger
{
    private FileInfo File { get; } = new FileInfo(filePath);

    public string FilePath { get => File.FullName; }

    public FileLogger(FileLoggerConfiguration configuration) : this(configuration.LogSource, configuration.FilePath) {}

    static ILogger ILogger.CreateLogger(in ILoggerConfiguration logggerConfiguration) => 
        logggerConfiguration is FileLoggerConfiguration configuration
            ? CreateLogger(configuration)
            : throw new ArgumentException("Invalid configuration type", nameof(logggerConfiguration));

    public static FileLogger CreateLogger(FileLoggerConfiguration configuration) => new(configuration);

    public override void Log(LogLevel logLevel, string message)
    {
        using StreamWriter writer = File.AppendText();
        writer.WriteLine($"{ DateTime.Now },{LogSource},{logLevel},{message}");
    }
}
