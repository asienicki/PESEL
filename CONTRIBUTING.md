# Contributing

Thank you for contributing to this project.
This document describes how to work with the repository and follow the established process.

---

## Development Workflow

- Create short-lived branches:
  - `feat/*`
  - `fix/*`
- Open a Pull Request targeting `master`
- Ensure CI checks are green before merge

---

## Release Process (Overview)

- Promotion to `rc` and `release` is **manual** and handled by maintainers.
- Contributors do not create or merge into `rc` or `release` branches.
- Released artifacts are published automatically by CI/CD.

For the full release architecture and rationale, see:
- [Branching & Release Flow](docs/release-process.md)
