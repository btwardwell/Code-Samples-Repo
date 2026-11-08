# Shopify CLI Reference Notes

The Shopify Command Line Interface (CLI) is a tool that helps you build Shopify apps, themes, and custom storefronts. 

It automates common development tasks and connects your local environment to your Shopify stores.

## Common Shopify CLI Commands

Here are the most frequently used commands, categorized by their primary use case (Themes vs. Apps).

### Theme Development Commands

*   **`shopify theme init`**: Clones the Dawn reference theme to your local machine to jumpstart a new theme project.
    *   *Example*: `shopify theme init my-new-theme`
*   **`shopify theme dev`**: Uploads the current theme as a hidden development theme to your store and starts a local server with hot-reloading. This is your primary command for local development.
    *   *Example*: `shopify theme dev --store my-store.myshopify.com`
*   **`shopify theme pull`**: Downloads theme files from a Shopify store to your local machine. Useful for syncing changes made via the Shopify admin editor.
    *   *Example*: `shopify theme pull -t [theme-id]`
*   **`shopify theme push`**: Uploads local theme files to a Shopify store, overwriting the remote files. 
    *   *Example*: `shopify theme push` (CLI will prompt you to select which theme to overwrite or create a new one).
*   **`shopify theme check`**: Runs Shopify's linter (Theme Check) to analyze your theme for Liquid syntax errors, performance issues, and best practices.
    *   *Example*: `shopify theme check`
*   **`shopify theme list`**: Lists all the themes installed on the connected store along with their IDs.
    *   *Example*: `shopify theme list`

### App Development Commands

*   **`shopify app init`**: Scaffolds a new Shopify app with your preferred language and stack (e.g., Node.js, Remix, PHP).
    *   *Example*: `shopify app init`
*   **`shopify app dev`**: Starts a local development server for your app, establishes an ngrok/Cloudflare tunnel, and updates your app's URLs in the Partner Dashboard automatically.
    *   *Example*: `shopify app dev`
*   **`shopify app generate`**: Generates app extensions (like theme app extensions, webhooks, or UI components).
    *   *Example*: `shopify app generate extension`
*   **`shopify app deploy`**: Builds your app and deploys your app extensions to Shopify.
    *   *Example*: `shopify app deploy`

---

## Shopify Version Control

**Does Shopify have built-in version control?**
Shopify does *not* have its own proprietary version control system, it relies on Git like most apps. 

Here is how version control works in the Shopify ecosystem:

1.  **Shopify GitHub Integration (For Themes):**
    *   You can connect your Shopify store directly to a GitHub repository.
    *   Once connected, you link specific Git branches (e.g., `main`, `staging`, `feature-x`) to specific themes in your store.
    *   When you commit and push changes to that branch on GitHub, Shopify automatically pulls the updates to the connected theme. Conversely, if a merchant makes a change in the Shopify Online Store Editor, Shopify automatically pushes a commit back to your GitHub branch.
2.  **Using Git with Shopify CLI:**
    *   The standard workflow is to initialize a Git repository in your local theme or app folder (`git init`).
    *   You use Git for actual version control (commits, branches, pull requests).
    *   You use the Shopify CLI (`shopify theme dev`) merely to preview those files on a development environment.
3.  **Theme Architecture Backups:**
    *   While not true version control, Shopify does keep a limited history of changes made to individual `.liquid` files *within the admin code editor*. You can roll back to older versions of a specific file, but this is highly discouraged for modern development compared to using Git.