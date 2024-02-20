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
                if (text != null)
                {
                    Assert.Equal(expectedOutput, text);
                }
                else
                {
                    Assert.True(false, "The output should not be null.");
                }
            },
            ReadLine = () =>
            {

                return userInput;
            }
        };

        program.WriteLine(program.ReadLine()!);


    }
}
