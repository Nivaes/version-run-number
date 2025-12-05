# Get Version Run Number

A GitHub Action which extracts the version from `github.ref`.

Finally, you can reliably get the pushed version on every platform.

## Outputs

### `version`

Si la branch se llama develop/0.1 generara la version 0.1-beta.1 

Si la branch se llama alpha/0.1 genera la version 0.1-alpha.1

Si la branch se llama preview/0.1 genera la version 0.1-preview.1

Si la branch se llama rc/0.1 genera la version 0.1-rc.1

Si la branch es llama rc/0.1 y parametro pre genera version 0.0-rc.1

Si la branch es release/0.1 y parametro pre genera version 0.0-rc.1

Si la branch es release/0.1 y sin parametro pre genera version 0.0.1

## Example usage

```YML
steps:
    - id: get_version
      uses: nivaes/version-pack@v2

    - run: echo ${{ steps.get_version.outputs.version }}

```
