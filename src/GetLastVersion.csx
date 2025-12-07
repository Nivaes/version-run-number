public int GetLastVersion(string branch)
{
    string lastVersion = RunCommand("git", "describe --tags --abbrev=0");

    if(!lastVersion.StartsWith(branch))
        return 0;

    var patchVersionSplit = lastVersion.Split(".");

    if(patchVersionSplit.Count() > 0)
    {
        lastVersion = patchVersionSplit[^1];
        if(int.TryParse(lastVersion, out var lastVersionNumber))
        {
            return lastVersionNumber + 1;
        }
    }

    return 0;
}