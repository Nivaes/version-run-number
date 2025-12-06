public int GetLastVersion()
{
    string lastVersion = RunCommand("git", "describe --tags --abbrev=0");

    var lastVersionNumber = 0;

    var patchVersionSplit = lastVersion.Split(".");

    if(patchVersionSplit.Count() > 0)
    {
        lastVersion = patchVersionSplit[^1];
        if(int.TryParse(lastVersion, out lastVersionNumber))
        {
            lastVersionNumber =lastVersionNumber;
        }
    }

    return lastVersionNumber;
}