# Agents

See [CONTRIB.md](CONTRIB.md) for coding style guide.

See [TODO.md](TODO.md) for the TODO list.  Delete items from the TODO list when
complete.  Each major TODO heading should be implemented as its own PR with its
own branch from main.

# Dev Environment

Codebase is using dotnet 10.0.

# Testing Problem

The docker container hosting the pi coding agent is using a version of dotnet
that is prone to OOM errors.  `dotnet test` in particular can start failing with
OOM.  Using testing frameworks thate generate an .exe from the tests and allow
testing via `dotnet run` on the test project tends to work better.  The
following package-list works well for this:

```
    <PackageReference Include="xunit.v3.mtp-v2" Version="3.2.2" />
    <PackageReference Include="xunit.v3.runner.console" Version="3.2.2" />
    <PackageReference Include="FluentAssertions" Version="7.2.2" />
```

## Workarounds

In that case, clear `/tmp`.  Also `dotnet run` the test project reduces
likelihood of OOM and still runs the tests.  You may have to use `top` and
`kill` to clear out orphaned dotnet processes.