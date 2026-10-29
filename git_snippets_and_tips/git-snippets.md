
### Git Snippets and Commands
![Git Logo](/images/git-logo.png "Git Verson Control")
##### Git Configuration Settings

When using Git and cloning repositories from Windows into a Linux environment (Virtualbox, WSL), you need to configure it to handle **EOL Conversion** to correctly clone.
**Example Error:**
```shell
vagrant@ubuntu-focal:~$ cd /srv/www
vagrant@ubuntu-focal:/srv/www$ bin/cake migrations migrate
/usr/bin/env: ‘sh\r’: No such file or directory
```
Fix with this command
**`git config --global core.autocrlf input`**
---

### Check status of .gitignore file to troubleshoot add/remove errors
```
git status --short && echo '---' && git check-ignore -v .github/workflows/import-jobs.yml || true
```

### Check the status of a github workflow
```
echo '--- tracked ---' && git ls-files --stage .github/workflows/import-jobs.yml || true && echo '--- ignored ---' && git status --short --ignored --untracked-files=all .github .github/workflows .github/workflows/import-jobs.yml || true && echo '--- add test ---' && git add --dry-run .github/workflows/import-jobs.yml 2>&1 || true
```