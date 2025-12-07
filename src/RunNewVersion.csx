#load "RunCommand.csx"
#load "GenerateVersionPatch.csx"
#load "GetLastVersion.csx"
#load "GenerateTag.csx"
using System;

string packageFlow = "";
if (Args.Count() > 0)
    packageFlow = Args[0];

string versionMajor = "0.0";

string branch = RunCommand("git", "rev-parse --abbrev-ref HEAD");
var branch_part = branch.Split("/");

if(branch_part.Count() > 1)
    versionMajor = branch_part[branch_part.Count() - 1];

var numberPatchVersion = GetLastVersion(branch);

string versionPatch = GenerateVersionPatch(packageFlow, branch_part[0]);

string version = $"{versionMajor}{versionPatch}";

GenerateTag($"{versionMajor}.{numberPatchVersion}");

Console.WriteLine($"{versionMajor}{versionPatch}.{numberPatchVersion}");
Console.WriteLine($"{versionMajor}.{numberPatchVersion}");