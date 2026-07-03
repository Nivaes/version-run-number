#load "RunCommand.csx"
#load "GenerateVersionPatch.csx"
#load "GetLastMinorVersion.csx"

(string versionNumber, string versionPack, string versionRelease) GenerateVersion(string versionRelease)
{
    var versionReleasePatch = versionRelease.Split("/");
    if (versionReleasePatch.Length > 1)
    {
        var patchType = versionReleasePatch[0];
        var version = versionReleasePatch[1];
        var versionPatch = version.Split(".");
        var versionMajor = string.Join(".", versionPatch[..^1]);
        var versionMinor = versionPatch[^1];

        string versionPrerelease = GenerateVersionPatch(patchType, "");

        var versionNumber = $"{versionMajor}.{versionMinor}";
        var versionPack = $"{versionMajor}{versionPrerelease}.{versionMinor}";

        return (versionNumber, versionPack, versionRelease);
    }
    else
    {
        throw new Exception($"Version release name '{versionRelease}' does not contain a valid version number.");
    }
}