using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class EntityTests
{
    [Fact]
    public void Student_GivenName_NameMatches()
    {
        
        string nameTest = "Cotton Eye Joe";
        FullName testName = new("Cotton", "Joe", "Eye");


        Student student = new(testName);


        Assert.Equal(nameTest, student.Name);

    }
    [Fact]
    public void Employee_GivenName_NameMatches()
    { 
        string nameTest = "Cotton Eye Joe";
        FullName testName = new("Cotton", "Joe", "Eye");


        Student employee = new(testName);

        Assert.Equal(nameTest, employee.Name);

    }
    [Fact]
    public void Book_NameMatches()
    {
        string titleTest = "Count your lucky stars";
        Book book = new(titleTest);

        Assert.Equal(titleTest, book.Title);
    }
}
