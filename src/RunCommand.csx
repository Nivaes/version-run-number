string RunCommand(string cmd, string args)
{
    var psi = new ProcessStartInfo {
        FileName = cmd,
        Arguments = args,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    var p = Process.Start(psi);
    string output = p.StandardOutput.ReadToEnd().Trim();
    string error = p.StandardError.ReadToEnd().Trim();
    p.WaitForExit();

    if (!string.IsNullOrWhiteSpace(error))
        Console.Error.WriteLine($"[ERR] {error}");

    return output;
}