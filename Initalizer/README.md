## Project: Initalizer
## Purpose: Connect the Client and RavenDB, initalize them and run them asynchronously
---
## Setup: 
- Add a `appsettings.json` file to this directory
- Edit file properties 
- - Build process => Content 
- - Copy to output directory => Always
- Copy this structure and replace all Variables that contain `()` with yours, corresponding to the provided key

```json
{
    "Discord":
    {
        "Token": (),
        "Status": (),
        "Prefixes": [()]
    },
    "RavenDB":
    {
        "URLs": [()],
        "Database": (),
        "Certificate": ()
    }
}
```