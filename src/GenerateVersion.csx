#load "RunCommand.csx"

enum Patch
{
    None,
    Preview,
    ReleaseCandidate,
    Release
}

string GenerateVersionPatch(IList<string> args, string patchType)
{
    string versionPatch;
    Patch patch = Patch.None;

    if (args.Count() > 0)
    {
        var arg = args[0].ToUpper();
        if(arg.Contains("CANDIDATE") || arg.Contains("RC"))
            patch = Patch.ReleaseCandidate;
        else if(arg.Contains("PRE"))
            patch = Patch.Preview;
    }

    if(patchType ==  "develop")
        versionPatch = $"-alpha";
    else if(patchType ==  "alpha")
        versionPatch = $"-alpha";
    else if(patchType ==  "beta")
        versionPatch = $"-beta.";
    else if(patchType ==  "preview")
        versionPatch = $"-preview";
    else if(patchType == "rc")
        versionPatch = $"-rc.";
    else if(patchType == "release")
    {
        if(patch == Patch.Preview)
            versionPatch = $"-preview";
        else if(patch == Patch.ReleaseCandidate)
            versionPatch = $"-rc";
        else
            versionPatch = $"";
    }
    else 
        versionPatch = $"-alpha";

    return versionPatch;
}