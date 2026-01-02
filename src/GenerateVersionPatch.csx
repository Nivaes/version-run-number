#load "RunCommand.csx"

string GenerateVersionPatch(string patchType)
{
    if(patchType.StartsWith("dev"))
        return $"-alpha";
    else if(patchType.StartsWith("a"))
        return $"-alpha";
    else if(patchType.StartsWith("b"))
        return $"-beta";
    else if(patchType.StartsWith("pre"))
        return "-preview";
    else if(patchType == "rc" || patchType.StartsWith("can"))
        return $"-rc";
    else if(patchType == "release")
        return $"";
    else 
        return $"-alpha";
}