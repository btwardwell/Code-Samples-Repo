## Copy-ready command list and purpose

Use the following in a terminal from the project root:

```bash
cd /Users/brianwardwell-17inch/sites/brianwardwell.net
```

Purpose:
- Move into the site root before running any PHP/security checks.

```bash
find . -path './blog' -prune -o -name '*.php' -print0 | xargs -0 grep -nE "preg_replace\s*\([^\n]*['\"][^\n]*['\"][^\n]*/e|preg_replace\s*\([^\n]*['\"][^\n]*['\"][^\n]*e[[:space:]]*[,)]|create_function\s*\(|assert\s*\s*\(|eval\s*\(" -- 2>/dev/null | head -200
```

Purpose:
- Scan non-WordPress PHP for the dangerous evaluation patterns commonly removed or deprecated in PHP 8, especially:
  - `eval()`
  - `assert()`
  - `create_function()`
  - `preg_replace(... /e ...)`

```bash
grep -RIl --exclude-dir=blog --include='*.php' -E "preg_replace\s*\([^\n]*['\"]/e|preg_replace\s*\([^\n]*['\"]\s*\.[^\n]*\$|create_function\s*\(|assert\s*\(" . 2>/dev/null | sed 's#^./##'
```

Purpose:
- Locate specific files outside `blog` that still contain risky dynamic-evaluation patterns.

```bash
grep -RIn --exclude-dir=blog --include='*.php' -E "create_function\s*\(|assert\s*\(|preg_replace\s*\([^\n]*['\"][^\n]*['\"][^\n]*\$|eval\s*\(" . 2>/dev/null | head -200
```

Purpose:
- Confirm the exact file and line locations of security-sensitive PHP patterns.

```bash
grep -RIn --exclude-dir=blog --include='*.php' -E "mysql_query|mysql_fetch_|mysql_error|mysql_num_rows|mysql_connect|mysql_select_db" . 2>/dev/null
```

Purpose:
- Check for deleted/unsupported legacy MySQL calls that break under PHP 8.

```bash
php -l phpmysqlexample/view_sort.php
```

Purpose:
- Run PHP syntax validation on the updated file to confirm it is valid under the active PHP version.

```bash
grep -RIn --exclude-dir=blog --include='*.php' -E "mysql_query|mysql_fetch_|mysql_error|mysql_num_rows|mysql_connect|mysql_select_db" . 2>/dev/null || true
```

Purpose:
- Re-check the non-WordPress PHP tree to ensure the removed `mysql_*` API is no longer in use.

---

## Additional security/sanitization checks worth running

These are useful for “input is escaped and code is sanitized” validation:

```bash
grep -RIn --exclude-dir=blog --include='*.php' -E "\$_(GET|POST|REQUEST|SERVER)\[.*\]|filter_input|htmlspecialchars|htmlentities|mysqli_real_escape_string|esc_html|esc_attr|strip_tags|trim" . 2>/dev/null | head -200
```

Purpose:
- Audit input handling and escaping patterns across PHP files, especially:
  - `$_GET`, `$_POST`, `$_REQUEST`
  - `filter_input()`
  - `htmlspecialchars()`
  - `mysqli_real_escape_string()`
  - escaping helpers used by frameworks

```bash
grep -RIn --exclude-dir=blog --include='*.php' -E "echo\s+\\$|print\s+\\$|\\$_(GET|POST|REQUEST)\[.*\]" . 2>/dev/null | head -200
```

Purpose:
- Look for unsanitized output or direct variable echoing into HTML.

```bash
php -d detect_unicode=0 -l ./*.php 2>/dev/null
```

Purpose:
- Run quick syntax checks on standalone PHP files.

> For a full site-wide PHP 8 audit, It's also recommended to use a linter and a static scanner such as PHPStan or Psalm, but the commands above are the exact ones used in this fix workflow.

If you want, I can also turn this into a single reusable shell script for future PHP 8 audits.