using System;

public int GetLastMinorVersion(string versionMajor)
{
    string commantgit = $"ls-remote --tags origin '{versionMajor}.*'";
    Console.WriteLine($"Running command: git {commantgit}");

    var lastVersions = RunCommand("git", $"ls-remote --tags origin '{versionMajor}.*'");
    Console.WriteLine($"Last versions for major version '{versionMajor}': {lastVersions}");

    if (string.IsNullOrWhiteSpace(lastVersions))
        return 0;

    var versions = lastVersions
        .Split('\n', StringSplitOptions.RemoveEmptyEntries);

    var version = versions
        .Select(tagName =>
        {
            var tagNameSplit = tagName.Split('.');
            if (tagNameSplit.Count() > 0)
            {
                if (int.TryParse(tagNameSplit[^1], out int version))
                    return version;
            }
            return -1;
        })
        .Distinct()
        .Max();

    return version;
}