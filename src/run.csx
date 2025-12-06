#load "RunCommand.csx"
#load "GenerateVersion.csx"

using System;

(string versionMajor, string versionMinor) = GenerateVersion(Args);

Console.WriteLine($"{versionMajor}{versionMinor}");
Console.WriteLine($"{versionMajor}");
Console.WriteLine($"{versionMinor}");
