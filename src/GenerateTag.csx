#load "RunCommand.csx"

public void GenerateTag(string version)
{
    RunCommand("git", "config --global user.email \"action@github.com\"");
    RunCommand("git", "config --global user.name \"gibhub action\"");

    RunCommand("git", $"tag -a {version} -m \"Version {version}\"");

    RunCommand("git", "push origin --tags");
}