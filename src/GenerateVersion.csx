#load "RunCommand.csx"

enum Patch
{
    None,
    Preview,
    ReleaseCandidate,
    Release
}

string GenerateVersionPatch(IList<string> args, string patchType, int numberPatchVersion)
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
        versionPatch = $"-alpha.{numberPatchVersion}";
    else if(patchType ==  "alpha")
        versionPatch = $"-alpha.{numberPatchVersion}";
    else if(patchType ==  "beta")
        versionPatch = $"-beta.{numberPatchVersion}";
    else if(patchType ==  "preview")
        versionPatch = $"-preview.{numberPatchVersion}";
    else if(patchType == "rc")
        versionPatch = $"-rc.{numberPatchVersion}";
    else if(patchType == "release")
    {
        if(patch == Patch.Preview)
            versionPatch = $"-preview.{numberPatchVersion}";
        else if(patch == Patch.ReleaseCandidate)
            versionPatch = $"-rc.{numberPatchVersion}";
        else
            versionPatch = $".{numberPatchVersion}";
    }
    else 
        versionPatch = $"-alpha.{numberPatchVersion}";

    return versionPatch;
}