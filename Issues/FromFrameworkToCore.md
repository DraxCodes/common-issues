# Migrating from .NET Framework to .NET Core
There are many reasons to migrate from .NET Framework to .NET Core. The main reason is being able to run your project in a Linux machine. I'll explain briefly how to migrate in this post.

>Keep in mind there are some packages you won't be able to run in .NET Core, but most of the time there is an alternative.

## TD;LR
- Create a backup of your .csproj file. Renaming it adding .bak at the end should do.
- Create another .csproj file with your project name (same name as your old .csproj) using [this](https://github.com/discord-bot-tutorial/Miunie/blob/master/src/Miunie.Core/Miunie.Core.csproj) csproj file as template. You won't have to change anything.
- Delete the `obj` folder.
- Add missing package references (for example, Discord.Net). There are different ways to do this. Using Visual Studio, running the `dotnet add package <packageName>` command, or adding it in the .csproj file.

- Open a terminal in your project folder (where the .csproj file is) and run `dotnet restore`.
- Now you can run your project with `dotnet run` or build it with `dotnet build`!

## The .csproj file
Your project is built based on the properties specified in its .csproj file. If you're using Visual Studio, probably you've never seen a .csproj file. Follow [this link](https://github.com/discord-bot-tutorial/discord-bot-tutorial/blob/master/DiscordTutorialBot/DiscordTutorialBot.csproj) to see a .NET Framwork .csproj file. It might be a bit scary, because there are a lot of weird words and characters in the file, and it's so big!
Before migrating, we should create a backup, just in case something goes wrong. To do that, copy your .csproj file, to _yourProjectName_.csproj.bak (appending .bak). 
The next step is replacing the content of your .csproj file to make it look like a .NET Core project. To do that, you can use [this file](https://github.com/discord-bot-tutorial/Miunie/blob/master/src/Miunie.Core/Miunie.Core.csproj) as template. 

## Deleting old .NET Framework packages
Your project packages are in the /obj/ folder. You can delete it, there's no risk at all. If you ever want to go back to .NET Framework, you'll still be able to, because those packages would be re-downloaded. Your project should be full of red underlines. That's good.

## Adding package references
To fix those errors, first we have to add the missing packages. Modern IDEs have features to automatically add missing package references, but I won't focus on that part, I will explain how to do that yourself, using the command line, and editing the .csproj file

### Using the command line
Using the command line might be scaring at first, but once you get used, you'll notice there are more benefits than using your IDE UI, for example:

- Helps to understand what's going on.
- If you have a basic knowledge about shell script, or any other script language able to run terminal commands, you could make cool scripts using `dotnet` commands, for example, a script to create a new project and init a git repository.
- Nowdays, every OS have a way to access a command line to execute `dotnet` commands, and you will probably face some situations in wich you don't have your IDE but want to create a project.

And there should be more benefits I missed. 
Anyway, back to the subject, to add a package reference using the CLI (command line interface) we have to follow this syntax:

```
dotnet add package <PackageName> --version=<version>
```
> Hint: use dotnet --help to see every avaliable command

So, if we want to add a reference to Discord.Addons.CommandsExtension, a set of extensions that provides an easy way to create a help command, we would have to run the following command: 
```
dotnet add package Discord.Addons.CommandsExtension --version 1.0.4
```
> Hint: If you don't want to remember that command, you don't have to! Simply go to the [nuget webpage](www.nuget.org), search for the package and select the `.NET CLI` tab, it'll provide the command to add it to your project.

### Editing the csproj file
I will assume Assuming you followed the steps in [The .csproj file](). This can be quite simple if you understand how the project file is structured, or quite hard if you never ever dealt with XML yourself. I could explain how the project file is structured, and everything you can configure editing it, but that's not the purpose of this guide.
To add a package reference, this is what you need to know:
- The package references are grouped inside a XML tag, `ItemGroup`. 
- You can declare a package references using the self-closing tag `PackageReference`.
- To indicate the package name, use the `Include` attribute.
- To indicate the package version, use the `Version` attribute.
So, if we add Discord.AddonsCommandsExtension, it would look like the following:
```
<ItemGroup>
    <PackageReference Include="Discord.Net" Version="2.0.1" />
    <PackageReference Include="Discord.AddonsCommandsExtension" Version="1.0.4" />
</ItemGroup>
```
## Restoring dependencies
We already added the packages to our project, but that's not enough, we have to download them!
In order to download the packages, open a terminal in the project directory (in the folder where the .csproj file is) and run the following command:
```
dotnet restore
```
And that's all! Now you can run your project with `dotnet run`!

If you have any issues, feel free to ask in the discord server, or open a new issue.

Author: [Charly#7094](https://github.com/Charly6596)

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)
