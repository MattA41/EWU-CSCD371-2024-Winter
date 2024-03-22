using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput, string? StdError);

public class PingProcess
{
    public static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress)
    {
        string pingArg = Environment.OSVersion.Platform is PlatformID.Unix ? "-c" : "-n";
        StartInfo.Arguments = $"{pingArg} 4 {hostNameOrAddress}";
        StringBuilder? stringBuilderOutput = null;
        StringBuilder? stringBuilderError = null;
        void updateStdOutput(string? line) =>
            (stringBuilderOutput??=new StringBuilder()).AppendLine(line);
        void updateStdErr(string? line) => 
            (stringBuilderError??=new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, updateStdErr, default);
        return new PingResult( process.ExitCode, stringBuilderOutput?.ToString(), stringBuilderError?.ToString());
    }
    
    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return new Task<PingResult>(() => Run(hostNameOrAddress));
        
    }

    public async Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            PingResult result = await Task.Run<PingResult>(() => { return Run(hostNameOrAddress); }, cancellationToken);
            return result;
        }
        catch (OperationCanceledException)
        {
            TaskCanceledException e = new();
            AggregateException ae = new(innerExceptions: e);
            throw ae;
        }

    }

    public async Task<PingResult> RunAsync(
        IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    {
        StringBuilder? stringBuilder = new();
        int total = 0;
        ParallelQuery<Task<int>>? all = hostNameOrAddresses.AsParallel().Select(async item =>
        {
            PingResult result = await RunAsync(item, cancellationToken);
            
            if (result.StdOutput != null)
            {
                lock(stringBuilder){
                    total += result.ExitCode;
                    stringBuilder.AppendLine(result.StdOutput.Trim());
                }
            }
            return result.ExitCode;
        });

        await Task.WhenAll(all);
        //int total = all.Aggregate(0, (total, item) => total + item.Result);
        return new PingResult(total, stringBuilder?.ToString().Trim(), default);
    }

    public async Task<PingResult> RunLongRunningAsync(ProcessStartInfo StartInfo,
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        string pingArg = Environment.OSVersion.Platform is PlatformID.Unix ? "-c" : "-n";
        StartInfo.Arguments = $"{pingArg} 4 {hostNameOrAddress}";
        StringBuilder? stringBuilderOutput = new();
        StringBuilder? stringBuilderError = new();
        void updateStdOutput(string? line) =>
            (stringBuilderOutput??=new StringBuilder()).AppendLine(line);
        void updateStdErr(string? line) => 
            (stringBuilderError??=new StringBuilder()).AppendLine(line);
        Task<PingResult> task = Task.Factory.StartNew<PingResult>(() => 
            {
                Process process = RunProcessInternal(StartInfo, updateStdOutput, updateStdErr, cancellationToken);
                return new PingResult(process.ExitCode, stringBuilderOutput.ToString(), default);
            }, 
            cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Current);
            return await task;
    }

    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        var process = new Process
        {
            StartInfo = UpdateProcessStartInfo(startInfo)
        };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorHandler;

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(obj =>
            {
                if (obj is Process p && !p.HasExited)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Win32Exception ex)
                    {
                        throw new InvalidOperationException($"Error cancelling process{Environment.NewLine}{ex}");
                    }
                }
            }, process);


            if (process.StartInfo.RedirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }
            if (process.StartInfo.RedirectStandardError)
            {
                process.BeginErrorReadLine();
            }

            if (process.HasExited)
            {
                return process;
            }
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'{Environment.NewLine}{e}");
        }
        finally
        {
            if (process.StartInfo.RedirectStandardError)
            {
                process.CancelErrorRead();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                process.CancelOutputRead();
            }
            process.OutputDataReceived -= OutputHandler;
            process.ErrorDataReceived -= ErrorHandler;

            if (!process.HasExited)
            {
                process.Kill();
            }

        }
        return process;

        void OutputHandler(object s, DataReceivedEventArgs e)
        {
            progressOutput?.Invoke(e.Data);
        }

        void ErrorHandler(object s, DataReceivedEventArgs e)
        {
            progressError?.Invoke(e.Data);
        }
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        return startInfo;
    }
}