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

var isPre = true;
var isRC = true;

if (Args.Count() > 0)
{
    if(Args[0].ToUpper().StartsWith("PRE"))
        isPre = true;
    if(Args[0].ToUpper().StartsWith("RC"))
        isRC = true;
}

string versionMajor = "0.0";
string versionMinor = "0";
string branch = Run("git", "rev-parse --abbrev-ref HEAD");
string numberComints = Run("git", "rev-list --count HEAD");

// branch = "develop";

var branch_part = branch.Split("/");


if(branch_part.Count() > 1)
    versionMajor = branch_part[branch_part.Count() - 1];

if(branch_part[0] ==  "develop")
    versionMinor = $"-beta.{numberComints}";
else if(branch_part[0] ==  "alpha")
    versionMinor = $"-alpha.{numberComints}";
else if(branch_part[0] ==  "beta")
    versionMinor = $"-beta.{numberComints}";
else if(branch_part[0] ==  "preview")
    versionMinor = $"-preview.{numberComints}";
else if(branch_part[0] ==  "rc" && isPre)
    versionMinor = $"rc.{numberComints}";
else if(branch_part[0] ==  "release" && isPre)
    versionMinor = $"rc.{numberComints}";
else if(branch_part[0] ==  "release")
    versionMinor = $".{numberComints}";
else 
    versionMinor = $"-alpha.{numberComints}";

Console.WriteLine($"{versionMajor}.{versionMinor}");
Console.WriteLine($"{versionMajor}");
Console.WriteLine($"{versionMinor}");
