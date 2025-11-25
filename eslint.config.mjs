import { defineConfig } from "eslint/config";
import jest from "eslint-plugin-jest";
import globals from "globals";
import path from "node:path";
import { fileURLToPath } from "node:url";
import js from "@eslint/js";
import { FlatCompat } from "@eslint/eslintrc";
import github from "eslint-plugin-github";

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const compat = new FlatCompat({
    baseDirectory: __dirname,
    recommendedConfig: js.configs.recommended,
});

export default defineConfig([
    {
        ignores: ["**/*.js","node_modules/**", "dist/**", "lib/**"],
    },
    {
        files: ["*.ts","*.tsx"],

        plugins: {
            jest,
            github,
        },

        languageOptions: {
            ecmaVersion: "latest",
            sourceType: "module",

            globals: {
                ...globals.browser,
                ...globals.node,
                jest: "readonly",
            },

            parserOptions: {
                project: "./tsconfig.json",
            },
        },

        rules: {
          
        },
    }
]);