#load "RunCommand.csx"
#load "GenerateVersionPatch.csx"
#load "GetLastMinorVersion.csx"
using System.Text.RegularExpressions;

(string versionNumber, string versionPack, string versionRelease) GenerateNewVersion(string prerelease)
{
    var branch = RunCommand("git", "rev-parse --abbrev-ref HEAD");

    var branchPart = branch.Split("/");

    var regex = new Regex(@"^\d+(\.\d+)*$");
    if (branchPart.Count() > 0 && regex.IsMatch(branchPart[^1]))
    {
        var versionMajor = branchPart[^1];
        var patchType = string.Concat(branchPart[..^1]);

        var numberPatchVersion = GetLastMinorVersion(versionMajor) + 1;

        string versionPrerelease = GenerateVersionPatch(patchType, prerelease, false);

        var versionNumber = $"{versionMajor}.{numberPatchVersion}";
        var versionPack = $"{versionMajor}{versionPrerelease}.{numberPatchVersion}";
        var versionRelease = $"{patchType}/{versionMajor}.{numberPatchVersion}";

        return (versionNumber, versionPack, versionRelease);
    }
    else
    {
        throw new Exception($"Branch name '{branch}' does not contain a valid version number.");
    }
}