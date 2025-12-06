#load "RunCommand.csx"
#load "GenerateVersion.csx"
#load "GetLastVersion.csx"
#load "GenerateTag.csx"
using System;

string versionMajor = "0.0";

string branch = RunCommand("git", "rev-parse --abbrev-ref HEAD");
var branch_part = branch.Split("/");

if(branch_part.Count() > 1)
    versionMajor = branch_part[branch_part.Count() - 1];

string numberComints = RunCommand("git", "rev-list --count HEAD");

var numberPatchVersion = GetLastVersion(branch);

string versionPatch = GenerateVersionPatch(Args, branch_part[0] , numberPatchVersion);

string version = $"{versionMajor}{versionPatch}";

GenerateTag(version);

Console.WriteLine(version);
Console.WriteLine($"{versionMajor}");
Console.WriteLine($"{versionPatch}");
