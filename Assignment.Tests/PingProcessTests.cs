using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Assignment.Tests;

[TestClass]
public class PingProcessTests
{
    PingProcess Sut { get; set; } = new();
    private bool IsUnix { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    //will never be null as it is set in tes initialize
    private string PingOutputLikeExpression { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [TestInitialize]
    public void TestInitialize()
    {
        IsUnix = Environment.OSVersion.Platform is PlatformID.Unix;
        Sut = new();
        if (IsUnix)
        {
            PingOutputLikeExpression = PingOutputLikeExpressionUnix;
        }
        else
        {
            PingOutputLikeExpression = PingOutputLikeExpressionWindows;
        }
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        if (IsUnix == false)
        {
            Process process = Process.Start("ping", "localhost");
            process.WaitForExit();
            Assert.AreEqual<int>(0, process.ExitCode);
        }
        else
        {
            Process process = Process.Start("ping", "-c 4 localhost");
            process.WaitForExit();
            Assert.AreEqual<int>(0, process.ExitCode);
        }
        
        
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int expectedExitCode = Environment.GetEnvironmentVariable("GITHUB_ACTIONS") is not null || IsUnix ? 1 : 0;
        int exitCode = Sut.Run("google.com").ExitCode;
        Assert.AreEqual<int>(expectedExitCode, exitCode);
    }


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (string expectedOutput, int expectedExitCode) = IsUnix ? ("ping: badaddress: Temporary failure in name resolution", 2) : ("Ping request could not find host badaddress. Please check the name and try again.", 1);
        (int exitCode, string? stdOutput, string? stdError) = Sut.Run("badaddress");
        string output = IsUnix ? stdError! : stdOutput!; 
        Assert.IsFalse(string.IsNullOrWhiteSpace(output));

        output = WildcardPattern.NormalizeLineEndings(output!.Trim());
        Assert.AreEqual<string?>(expectedOutput, output, $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(expectedExitCode, exitCode);
    }

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult result = Sut.Run("localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    //testing to see if the task ended correctly
    {
         Task<PingResult> output = Sut.RunTaskAsync("localhost");
         
         output.Start();

         AssertValidPingOutput(output.Result);
        // Do NOT use async/await in this test.
        // Test Sut.RunTaskAsync("localhost");
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
        Task<PingResult> task = Task.Run<PingResult>(() => Sut.RunAsync("localhost"));
        PingResult result = task.Result;
        // Test Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public async Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.
        PingResult result = await Sut.RunAsync("localhost");

        // Test Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public Task RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        CancellationTokenSource stopToken = new ();
        Task<PingResult> task = Task.Run(() => Sut.RunAsync("localhost", stopToken.Token));
        stopToken.Cancel();
        return task;
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public async Task RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        try
        {
            CancellationTokenSource stopToken = new();
            stopToken.Cancel();
            await Sut.RunAsync("localhost", stopToken.Token);
            
        }
        catch (AggregateException ae)
        {
            foreach (var e in ae.Flatten().InnerExceptions)
            {
                if (e is TaskCanceledException)
                {
                    throw e;

                }
            }
        }

        // Use exception.Flatten()
    }

    [TestMethod]
    public async Task RunAsync_MultipleHostAddresses_True()
    {
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length*hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual<int?>(expectedLineCount, lineCount);
    }

    [TestMethod]
    public async Task RunLongRunningAsync_UsingTpl_Success()
    {
        ProcessStartInfo startInfo = new("ping");
        if (IsUnix)
        {
            startInfo = new ("ping", "-c 4 localhost");
        }
        PingResult result = await Sut.RunLongRunningAsync(startInfo,"localhost");
        // Test Sut.RunLongRunningAsync("localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count()+1);
    }

    readonly string PingOutputLikeExpressionWindows = @"
Pinging * with 32 bytes of data:
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*

Ping statistics for ::1:
    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = *, Maximum = *, Average = *".Trim();

    readonly string PingOutputLikeExpressionUnix = @"
PING * * bytes*
64 bytes from * (*): icmp_seq=* ttl=* time=* ms
64 bytes from * (*): icmp_seq=* ttl=* time=* ms
64 bytes from * (*): icmp_seq=* ttl=* time=* ms
64 bytes from * (*): icmp_seq=* ttl=* time=* ms

--- * ping statistics ---
* packets transmitted, * received, *% packet loss, time *ms
rtt min/avg/max/mdev = */*/*/* ms
".Trim();
    private void AssertValidPingOutput(int exitCode, string? stdOutput)
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression)??false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
