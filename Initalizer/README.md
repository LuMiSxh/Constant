## Project: Initalizer

## Purpose: Connect the Client and RavenDB, initalize them and run them asynchronously

---

## Setup

- Add a `appsettings.json` file to this directory
- Edit file properties
  - - Build process => Content
  - - Copy to output directory => Always
- Copy this structure and replace all Variables with yours, corresponding to the provided key

```json
{

 "Discord": {
  "Token": "Your Token",
  "Status": "Your Status",
  "Prefixes": [ "Your Prefix" ]
 },

 "RavenDB": {
  "URLs": [ "Your Cluster URL" ],
  "Database": "Your Database Na,e",
  "Certificate": "Your Certificate .pfx"
 },

 "Emojis": {
  "Hitman": {
   "Perks": {
    "ExtendedScope": "Emoji Id (Example <:PerkVariableScope:901203525999132733>)",
    "VariableScope": "Emoji Id",
    "VersatileScope": "Emoji Id",
    "Marksman": "Emoji Id",
    "Piercing": "Emoji Id",
    "SteadyAim": "Emoji Id",
    "Subsonic": "Emoji Id",
    "Suppressor": "Emoji Id"
   },
   "Weapons": {
    "Container": "Emoji Id",
    "Distraction": "Emoji Id",
    "Explosive": "Emoji Id",
    "Firearm": "Emoji Id",
    "Melee": "Emoji Id",
    "Poison": "Emoji Id",
    "Tool": "Emoji Id"
   }
  }
 }
}
```
