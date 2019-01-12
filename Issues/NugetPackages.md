<p align="center">
    <img src="../Images/Nuget Packages.png">
</p>

# Nuget packages

The best way to think of a Nuget package is that it is essentially an addon you can use in your Project. You can use Nuget packages to work with JSON, Access an API or Work With Graphics and many more things. If you have an idea but you're not sure it's possible, check Nuget and see if there is a package that already does the job.

## Installing

Installing Nuget packages is really simple and it generally just depends on your use case. (What IDE or Code Editor you're using) It also tends to depend on what you're wanting to do, are you adding packages to a new project or are you just wanting to get packages for a project that is already in development. Below is a few examples that should have you understanding Nuget.

### Visual Studio IDE (Installing Nuget Packages)

Installing packages in the Visual Studio IDE is by far one of the easiest.

- First start off by opening your project if you havn't already done so.
- Once you project is loaded, you should be able to see the Solution Explorer (Right hand side)
- Inside the solution explorer you should see an item named `Dependencies`
- you want to right click this and select `Manage Nuget Packages`
- This will open the Nuget Package Manager, which is Visual Studio IDE is a nice GUI for us to use.
- Now it's as simple as going to browse, finding the package you want and installing it.
- **NOTE** You may see popups asking you to accept licenses, don't worry as this is normal, just accept them.

### Visual Studio Code (Installing Nuget Packages)

Installing packages in Visual Studio Code is slightly different as it requires you to first get an extention, then use a shortcut and commands to install them. However it is super intuitive so you shouldn't have too much issue with it.

- First you want to open your Project in Visual Studio Code
- Once it is open, on the left hand side you will see an icon that looks like : ![Image](https://i.gyazo.com/ca0388cf9becd6d0b46f4b3009dfa8c9.png)
- Click that icon and you should be presented with the extension manager.
- At the top there is a search bar. Search for the extension `Nuget`
- Install the extension `Nuget Package Manager`
- Once it is installed it will ask you to reload, just click the `reload` button.

Now you have it installed, you want to start adding packages

- First use the keyboard shortcut `Ctrl + Shift, P` this will open a bar at the top that you can use to run commands.
- In the bar, type `Nuget`, you should see one come up that says `Nuget Package Manager: Add Package`
- Make sure that is highlighted and click enter.
- Now in the same section, type the name of the package you want to install and hit enter.
- Next select the package you want from the options it shows you and hit enter.
- Next select the version you want and hit enter.
- Now the package should install for you.
- **NOTE** Once it is installed you may be asked to restore. Just click the restore button and you're good to go using the Nuget Package.

## Restoring Packages

Sometimes when you're working with Github or you're moving your project from one P.C to another you will end up in the situation where you're already using Nuget packages but the P.C you're now on, doesn't have them available. This is a common thing to occur and there is a simple fix for it.

### Prerequisites

- The Dotnet Runtime for your OS:
  - Found here: [.Net Core Runtime](https://dotnet.microsoft.com/download)
- The Git CLI
  - Found here: [Git CLI](https://git-scm.com/downloads)

### Restoring

- Start by going to the directory of your project that contains the `.sln`.
- Once in the directory you're going to want to right click anywhere in the explorer window and select `Git Bash Here`.
- This will open the terminal that you can use commands from.
- Now all you have to type is `dotnet restore` dotnet will restore any packages that are used in your project.

---

That's it for this guide. If none of the above guide covers your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)
