using Calculate;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CalculateTests;
public class ProgramTests
{
    [Fact]
    public void TestConsoleOutput()
    {

        string expectedOutput = "Hello, World!";
        string userInput = "World";

        Calculate.Program program = new()
        {
            WriteLine = (text) =>
            {
                Assert.Equal(expectedOutput, text);
            },
            ReadLine = () =>
            {

                return userInput;
            }
        };

        program.WriteLine(program.ReadLine());


    }
}
