using System;
using System.Runtime.CompilerServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void Test_ConfigureFileLogger_Good_Value()
    {
        LogFactory factory = new();
        factory.ConfigureFileLogger("C:");
        BaseLogger? log = factory.CreateLogger(nameof(Test_ConfigureFileLogger_Good_Value));
        Assert.IsNotNull(log);
    }
    [TestMethod]
    public void Test_CreateLogger_WithNullFilepath()
    {
        LogFactory factory = new(); 
        factory.ConfigureFileLogger(null);
        BaseLogger? log = factory.CreateLogger(nameof(Test_CreateLogger_WithNullFilepath));
        Assert.IsNull(log);
    }
    

}
