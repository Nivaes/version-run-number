#load "RunCommand.csx"

public void GenerateTag(string version)
{
    RunCommand("git", "config --global user.email \"github-action[bot]@github.com\"");
    RunCommand("git", "config --global user.name \"github-action[bot]\"");

    RunCommand("git", $"tag -a {version} -m \"Version {version}\"");

    RunCommand("git", "push origin --tags");
}