# Constant - The Discord Bot
Constant is a new Discord Bot written in C# (.NET Version 5.x) and will be used for many different things.
This Package is written and Maintained by [Drageast](https://github.com/Drageast) only, but new contributors are welcome.
---
## Dependencies (using NuGet):

**[Initalizer:](Initalizer/)**
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.Json
- Microsoft.Extensions.Configuration.EnvoirmentVariables

**[Client:](Client/)**
- DSharpPlus ([SlimGet - Nigthly build](https://dsharpplus.github.io/articles/misc/nightly_builds.html))
- DSharpPlus.CommandsNext ([SlimGet - Nigthly build](https://dsharpplus.github.io/articles/misc/nightly_builds.html))
- DSharpPlus.Interactivity ([SlimGet - Nigthly build](https://dsharpplus.github.io/articles/misc/nightly_builds.html))
- DsharpLus.SlashCommands ([SlimGet - Nigthly build](https://dsharpplus.github.io/articles/misc/nightly_builds.html))
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.Binder

**[RavenDB:](RavenDB/)**
- RavenDB.Client
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.Binder

---
## How to run: The entry point to this program is the Initalizer.
## Run this Project and the Raven database, as well as the Discord client should start