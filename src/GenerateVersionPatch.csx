#load "RunCommand.csx"

string GenerateVersionPatch(string patchType, string prerelease)
    {
        patchType = patchType.ToLower();
        prerelease = prerelease.ToLower();

        if (prerelease == "alpha")
            return $"-alpha";
        else if (prerelease == "beta")
            return $"-beta";
        else if (prerelease == "rc")
            return $"-rc";

        if (patchType.StartsWith("dev"))
            return $"-alpha";
        else if (patchType.StartsWith("a"))
            return $"-alpha";
        else if (patchType.StartsWith("b"))
            return $"-beta";
        else if (patchType.StartsWith("pre"))
            return "-preview";
        else if (patchType == "rc" || patchType.Contains("can"))
            return $"-rc";

        if(string.IsNullOrEmpty(prerelease))
            return $"";
        else
            return $"-preview";
    }