#load "RunCommand.csx"

public void GenerateTag(string version)
{
    RunCommand("git", $"tag -a {version} -m \"Version {version}\"");

    RunCommand("git", "push origin --tags");
}