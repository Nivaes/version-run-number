public int GetLastVersion(string versionMajor)
{
    string lastVersions = RunCommand("git", $"--no-pager tag --list \"{versionMajor}.*\"");

    var version = lastVersions
        .Split('\n', StringSplitOptions.RemoveEmptyEntries)
        .Select(tagName =>
        {
            var tagNameSplit = tagName.Split('.');
            if(tagNameSplit.Count() > 0)
            {
                if(int.TryParse(tagNameSplit[^1], out int version))
                    return version;
            }
            return -1;
        })
        .Distinct()
        .Max();

    return version + 1;
}