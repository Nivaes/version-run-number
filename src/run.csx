using System;

string Run(string cmd, string args)
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

string branch = Run("git", "rev-parse --abbrev-ref HEAD");
Console.WriteLine($"Branch: {branch}");

var versionMajor = "2.3";
var versionMinor = "6";

Console.WriteLine($"{versionMajor}.{versionMinor}");
Console.WriteLine($"{versionMajor}");
Console.WriteLine($"{versionMinor}");
