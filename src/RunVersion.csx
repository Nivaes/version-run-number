#load "GenerateNewVersion.csx"
#load "GenerateVersion.csx"
#load "GenerateTag.csx"

public (string numberVersion, string versionPack, string versionRelease) RunVersion(string prerelease, string version)
{
    if(string.IsNullOrWhiteSpace(version))
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