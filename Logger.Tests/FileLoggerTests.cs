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
        FileLogger fileLogger = new("");
        Assert.IsFalse(fileLogger._filePath == null);

    }
    
}
