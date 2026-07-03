string RunCommand(string cmd, string args)
{
 using var process = new Process();

    process.StartInfo = new ProcessStartInfo
    {
        FileName = cmd,
        Arguments = args,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    process.Start();

    var outputTask = process.StandardOutput.ReadToEndAsync();
    var errorTask = process.StandardError.ReadToEndAsync();

    process.WaitForExit();

    Task.WaitAll(outputTask, errorTask);

    var output = outputTask.Result.Trim();
    var error = errorTask.Result.Trim();

    if (!string.IsNullOrWhiteSpace(error))
        Console.Error.WriteLine(error);

    if (process.ExitCode != 0)
        throw new Exception($"'{cmd}' end with code {process.ExitCode}");

    return output;
}