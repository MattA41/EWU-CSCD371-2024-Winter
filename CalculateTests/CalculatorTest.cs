using Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTests;
public class CalculatorTest
{
    [Fact]
    public void CalculateAdd_Expected()
    {
        Assert.Equal(2, Calculator.Add(1, 1));
    }
    [Fact]
    public void CalculateMultiple_Expected()
    {
        Assert.Equal(1, Calculator.Multiple(1, 1));
    }
    [Fact]
    public void CalculateDivide_Expected()
    {
        Assert.Equal(2, Calculator.Divide(2, 1));
    }
    [Fact]
    public void CalculateSubtract_Expected()
    {
        Assert.Equal(0, Calculator.Subtract(1, 1));
    }

}

