#load "RunCommand.csx"
#load "GenerateVersionPatch.csx"
#load "GetLastVersion.csx"
#load "GenerateTag.csx"
using System;
using System.Text.RegularExpressions;

public (string numberVersion, string versionPack, string versionRelease) RunUpdateVersion(string version, string packageFlow)
{
    string versionMajor = "0.0";
    string numberPatchVersion = "0";
    // string prefixBranch = "";
    string prefixVersion = "";

    var version_split = version.Split("/");
    if(version_split.Count() > 0)
    {
        prefixVersion = string.Join("/", version_split[..^1]);
        var regex = new Regex(@"^\d+(\.\d+)*$");

        if(regex.IsMatch(version_split[^1]))
        {
            var version_split_split = version_split[^1].Split(".");
            if(version_split_split.Count() > 0)
            {
                versionMajor = string.Join(".", version_split_split[..^1]);
                numberPatchVersion = version_split_split[^1];
            }
        }
    }
    else
    {
        prefixVersion = version;
    }

    string versionPatch = GenerateVersionPatch(packageFlow, prefixVersion);

    var versionNumber = $"{versionMajor}.{numberPatchVersion}";
    var versionPack = $"{versionMajor}{versionPatch}.{numberPatchVersion}";
    var versionRelease = $"{prefixVersion}/{versionMajor}.{numberPatchVersion}";

    return (versionNumber, versionPack, versionRelease);
}
