using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CanHazFunny.Tests;
    public class OutputServiceTests
    {
        [Fact]
        public void TestPrintMethod()
        {
            OutputService outputService = new();

            using var sw = new StringWriter();
            Console.SetOut(sw);


                outputService.Print("Test Joke");

                
                string printedOutput = sw.ToString().Trim(); 
                Assert.Equal("Test Joke", printedOutput);
            
        }
    }

