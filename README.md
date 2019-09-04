# StepBackWall

### The "Step Back" wall is finally back!
No longer will you unknowingly walk out of the room or smack your TV without really meaning it while playing Beat Saber!

<p align="left">
  <img src="https://i.imgur.com/Lp1koue.jpg" width="430" title="stepbackwall">
</p>

---

Gotten tired of the walls already? No worries! You can turn it off from the settings menu

## For developers

### Contributing to CustomNotes
In order to build this project, please create the file `StepBackWall.csproj.user` and add your Beat Saber directory path to it in the project directory like this.
This file should not be uploaded to GitHub and is in the .gitignore.

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- Set "YOUR OWN" Beat Saber folder here to resolve most of the dependency paths! -->
    <BeatSaberDir>E:\Program Files (x86)\Steam\steamapps\common\Beat Saber</BeatSaberDir>
  </PropertyGroup>
</Project>
```

If you plan on adding any new dependencies which are located in the Beat Saber directory, it would be nice if you edited the paths to use `$(BeatSaberDir)` in `StepBackWall.csproj`

```xml
...
<Reference Include="BS_Utils">
  <HintPath>$(BeatSaberDir)\Plugins\BS_Utils.dll</HintPath>
</Reference>
<Reference Include="IPA.Loader">
  <HintPath>$(BeatSaberDir)\Beat Saber_Data\Managed\IPA.Loader.dll</HintPath>
</Reference>
...
```
