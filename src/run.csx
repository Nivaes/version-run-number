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

var isPreview = false;
var isReleaseCandidate = false;

if (Args.Count() > 0)
{
    var arg = Args[0].ToUpper();
    if(arg.Contains("CANDIDATE") || arg.Contains("RC"))
        isReleaseCandidate = true;
    else if(arg.Contains("PRE"))
        isPreview = true;
}

string versionMajor = "0.0";
string versionMinor = "0";
string branch = Run("git", "rev-parse --abbrev-ref HEAD");
string numberComints = Run("git", "rev-list --count HEAD");

branch = "release/1.15";

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
else if(branch_part[0] == "rc")
    versionMinor = $"-rc.{numberComints}";
else if(branch_part[0] == "release")
{
    if(isPreview)
        versionMinor = $"-preview.{numberComints}";
    else if(isReleaseCandidate)
        versionMinor = $"-rc.{numberComints}";
    else
        versionMinor = $".{numberComints}";
}
else 
    versionMinor = $"-alpha.{numberComints}";

Console.WriteLine($"{versionMajor}{versionMinor}");
Console.WriteLine($"{versionMajor}");
Console.WriteLine($"{versionMinor}");
