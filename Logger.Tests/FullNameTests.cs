using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Logger.Tests;

public class FullNameTests
{
    [Fact]
    public void FullName_NullMiddleName_StillValid()
    {
        FullName name = new("Cotton", "Joe");
        string nameTest = "Cotton Joe";
        Assert.Equal(nameTest, name.Name);
    }
    [Fact]
    public void FullName_NonNullMiddleName_StillValid()
    {
        FullName name = new("Cotton", "Joe", "Eye");
        string nameTest = "Cotton Eye Joe";
        Assert.Equal(nameTest, name.Name);
    }
    [Fact] 
    public void NoFirstName_ThrowsException()
    {
        
        Assert.Throws<ArgumentNullException>(() => new FullName(null!, "Joe", "Eye"));
    }
    [Fact]
    public void NoLastName_ThrowsException()
    {

        Assert.Throws<ArgumentNullException>(() => new FullName("Cotton", null!, "Eye"));
    }
}
