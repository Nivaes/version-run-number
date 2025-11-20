import * as core from "@actions/core";
import * as github from "@actions/github";

async function getBranchName(): Promise<string> {
  const ref = github.context.ref;
  let branchName = "";

  if (ref.startsWith("refs/heads/")) {
    branchName = ref.replace(/^refs\/heads\//, "");
  } else if (ref.startsWith("refs/tags/")) {
    branchName = ref.replace(/^refs\/tags\//, "");
  }
  return branchName;
}

async function getSubVersion(branchName: string): Promise<any> {
  const token = core.getInput("token", {required: true});
  const octokit = github.getOctokit(token);

  const {owner, repo} = github.context.repo;

  // Lista TODAS las workflow runs del repo
  const releases = await octokit.rest.repos.listReleases({
    owner,
    repo,
    per_page: 50 // puedes aumentar de 1 a 100
  });

  const filtered = releases.data.filter(r => r.tag_name.startsWith(branchName));

  if (filtered.length == 0) {
    return 1;
  } else {
    return filtered.length + 1;
  }
}

async function run(): Promise<void> {
  try {
    const branchName = await getBranchName();

    core.debug(`branchName: ${branchName}`);

    let version = branchName.split("/").pop();
    let subVersion = await getSubVersion(branchName);

    core.debug(`Version: ${version}`);
    core.setOutput("version", version);
    core.setOutput("tag-release", `${version}.${subVersion}`);
  } catch (error: any) {
    core.setFailed(error.message);
  }
}

run();
