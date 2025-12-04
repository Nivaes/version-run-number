const { execSync } = require('child_process');
const core = require('@actions/core');

try {
    // const name = core.getInput('name');
    
    const output = execSync(`dotnet run --project src/generate-version.cs`).toString().trim();
    core.setOutput('version', output);
} catch (error) {
    core.setFailed(error.message);
}