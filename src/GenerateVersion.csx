#load "RunCommand.csx"

(string versionMajor, string versionMinor) GenerateVersion(IList<string> args)
{
    var isPreview = false;
    var isReleaseCandidate = false;

    if (args.Count() > 0)
    {
        var arg = args[0].ToUpper();
        if(arg.Contains("CANDIDATE") || arg.Contains("RC"))
            isReleaseCandidate = true;
        else if(arg.Contains("PRE"))
            isPreview = true;
    }

    versionMajor = "0.0";
    versionMinor = "0";
    string branch = RunCommand("git", "rev-parse --abbrev-ref HEAD");
    string numberComints = RunCommand("git", "rev-list --count HEAD");

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

    return (versionMajor, versionMinor);
}