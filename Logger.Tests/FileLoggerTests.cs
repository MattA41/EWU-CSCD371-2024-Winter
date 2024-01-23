using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json.Serialization;

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
    [TestMethod]
    public void Test_LogToString_String_True()
    {
        FileLogger test = new FileLogger("test");
        string toStringTest = test.LogToString(LogLevel.Error,"it broke",nameof(Test_LogToString_String_True));
        string expectedToString = DateTime.Now.ToString("MMM dd yyyy, hh:mm:ss") + LogLevel.Error + "it broke" + nameof(Test_LogToString_String_True);
        Assert.AreEqual(expectedToString, toStringTest);
    }
}
