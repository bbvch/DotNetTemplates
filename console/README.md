# bbv .NET solution template

## Getting started

> dotnet test

The following files need manual attention:

1. [Directory.Build.props](./Directory.Build.props)
   - Target Framework(s)
   - RuntimeIdentifiers
1. [global.json](./global.json)
1. this README file

Then:

1. Update all NuGet packages

## Opinions

- Minimal [.gitignore](./.gitignore), update as needed.
  This help your heirs to understand the tools to use.
- Define common properties in [Directory.Build.props](./Directory.Build.props)
