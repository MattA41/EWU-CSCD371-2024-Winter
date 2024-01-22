using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void FileLogger_EmptyFilePath()
    {
        FileLogger fileLogger = new FileLogger("");
        Assert.IsFalse(fileLogger.filePath == null);

    }
}
