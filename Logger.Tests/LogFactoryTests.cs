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
        LogFactory factory = new LogFactory();
        factory.ConfigureFileLogger("C:");
        factory.CreateLogger(nameof(Test_ConfigureFileLogger_Good_Value));
        Assert.IsNotNull(factory);
    }
    [TestMethod]
    public void Test_CreateLogger_WithNullFilepath()
    {
        LogFactory factory = new LogFactory(); 
        factory.ConfigureFileLogger(null);
        factory.CreateLogger(nameof(Test_CreateLogger_WithNullFilepath));
        Assert.IsNull(factory);
    }
    

}
