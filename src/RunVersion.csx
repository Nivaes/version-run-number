#load "RunCommand.csx"
#load "GenerateVersionPatch.csx"
#load "GetLastMinorVersion.csx"
#load "GenerateTag.csx"

public (string numberVersion, string versionPack, string versionRelease) RunVersion(string prerelease, string version)
{
    if(!string.IsNullOrWhiteSpace(prerelease))
    {
        return GenerateNewVersion(prerelease);
    }
    if(!string.IsNullOrWhiteSpace(version))
    {
        return GenerateVersion(version);
    }
    else
    {
        throw new Exception($"No valid input provided. Please provide either a prerelease or version.");
    }
}