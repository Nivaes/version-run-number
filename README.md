# Get Version Run Number

A GitHub Action which extracts the version from `github.ref`.

Finally, you can reliably get the pushed version on every platform.

## Outputs

### `version`

The pushed version. If `github.ref` was `/refs/tags/release/v2.6` or `refs/tags/2.6` then the value of this output will be `2.6.24`.

## Example usage

````YML
steps:
    - id: get_version
      uses: nivaes/version-run-number@v1

    - run: echo ${{ steps.get_version.outputs.version }}

````
