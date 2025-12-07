#load "RunCommand.csx"

enum Patch
{
    None,
    Preview,
    ReleaseCandidate,
    Release
}

string GenerateVersionPatch(string patchBranch, string patchType)
{
    string versionPatch;
    Patch patch = Patch.None;

    patchBranch = patchBranch.ToUpper();
    if(patchBranch.Contains("CANDIDATE") || patchBranch.Contains("RC"))
        patch = Patch.ReleaseCandidate;
    else if(patchBranch.Contains("PRE"))
        patch = Patch.Preview;

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