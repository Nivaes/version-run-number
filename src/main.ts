import * as core from "@actions/core";
import * as github from "@actions/github";

async function getSubVersion(): Promise<any> {
    const branchName = github.context.ref_name;

    const token = core.getInput("token", { required: true });
    const octokit = github.getOctokit(token);

    const owner = github.context.repository.owner;
    const repo = github.context.repository.repo;

      // Lista TODAS las workflow runs del repo
    const runs = await octokit.rest.actions.listReleases({
          owner,
          repo,
          per_page: 50 // puedes aumentar de 1 a 100
      });

      const filtered = releases.data.filter(r =>
          r.tag_name.startsWith(branchName));

      if(filtered.length == 0) {
        return 1;
      } else {
        return filtered.length + 1;
      }
  }

async function run(): Promise<void> {
  try {
    const branchName = github.context.ref_name.split("/").pop();
    core.debug(`branchName: ${branchName}`);

    let version = `${branchName}`;
    let subVersion = await getSubVersion(); 

    core.debug(`Version: ${version}`);
    core.setOutput("version", version);
    core.setOutput("tag-release", `${version}.${subVersion}`);
    
  } catch (ex) {
    core.setFailed(ex.message);
  }
}

run();
