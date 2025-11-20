"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || (function () {
    var ownKeys = function(o) {
        ownKeys = Object.getOwnPropertyNames || function (o) {
            var ar = [];
            for (var k in o) if (Object.prototype.hasOwnProperty.call(o, k)) ar[ar.length] = k;
            return ar;
        };
        return ownKeys(o);
    };
    return function (mod) {
        if (mod && mod.__esModule) return mod;
        var result = {};
        if (mod != null) for (var k = ownKeys(mod), i = 0; i < k.length; i++) if (k[i] !== "default") __createBinding(result, mod, k[i]);
        __setModuleDefault(result, mod);
        return result;
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
const core = __importStar(require("@actions/core"));
const github = __importStar(require("@actions/github"));
async function getBranchName() {
    const ref = github.context.ref;
    let branchName = "";
    if (ref.startsWith("refs/heads/")) {
        branchName = ref.replace(/^refs\/heads\//, "");
    }
    else if (ref.startsWith("refs/tags/")) {
        branchName = ref.replace(/^refs\/tags\//, "");
    }
    return branchName;
}
async function getSubVersion(branchName) {
    const token = core.getInput("token", { required: true });
    const octokit = github.getOctokit(token);
    const { owner, repo } = github.context.repo;
    // Lista TODAS las workflow runs del repo
    const releases = await octokit.rest.repos.listReleases({
        owner,
        repo,
        per_page: 50, // puedes aumentar de 1 a 100
    });
    const filtered = releases.data.filter((r) => r.tag_name.startsWith(branchName));
    if (filtered.length == 0) {
        return 1;
    }
    else {
        return filtered.length + 1;
    }
}
async function run() {
    try {
        const branchName = await getBranchName();
        core.debug(`branchName: ${branchName}`);
        let version = branchName.split("/").pop();
        let subVersion = await getSubVersion(branchName);
        core.debug(`Version: ${version}`);
        core.setOutput("version", version);
        core.setOutput("tag-release", `${version}.${subVersion}`);
    }
    catch (error) {
        core.setFailed(error.message);
    }
}
run();
