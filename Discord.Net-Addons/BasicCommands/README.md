<p align="center">
    <img src="../../Images/CommandsGuide/TheBasics.png">
</p>

# Basic Command Guide Discord.Net 2.0

### This will cover the basics of setting up your own custom command modules in Discord.Net 2.0

**NOTE This guide is for command modules only. it does not explain how to setup your whole bot**

### Getting Started - Modules

Modules are at the core of every command you make in Discord.Net 2.0, They're essentially classes that hold sets of command Tasks that your bot can see and understand.

To create a new module, you first want to make a new folder in your project. This can be named anything, however try stick to a naming convertion that will be easy to understand.

- Common Names Are `Modules & Commands`

Once you have your new folder in your project you will want to create a new class inside it, name it something relevent to the type of commands you're making. I'm going to call this one `BasicCommandGuide`. Once you make the new class you should have something that looks like this.

```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace Botwyn.Modules
{
    class BasicCommandGuide
    {
    }
}
```

The first thing we're going to want to do with this new class is make it public. We do this because without it being public, the `CommandServive` (A Service in the Discord.Net Library) wont be able to see our commands. 

However just making it public isn't enough, we also have to inherit from what's called the `ModuleBase<SocketCommandContext>`. I'm not going to explain what that is here as it would take too long, however the simplist way to explain why we need it is, any class that inherits from `ModuleBase<SocketCommandContext>` is found by the `Command Service` so we can use the command we make in Discord.

You should now have a class that looks like this

```cs
//You need to add this using statement so the class knows where to find ModuleBase<>
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botwyn.Modules
{
    public class BasicCommandGuide : ModuleBase<SocketCommandContext>
    {

    }
}
```

Now we have our class setup we can start adding commands. Our first command is going to be the good old !ping command. Read through the comments in the below example to understand what is going on.

```cs
public class BasicCommandGuide : ModuleBase<SocketCommandContext>
{
    //The is how we set what we want the command to be that we use in discord.
    [Command("Ping")]
    //Here we create our new async Task which is essentially a Method the bot uses when the command !ping is ran.
    public async Task Ping()
    {
        //This is what the bot is going to do when it runs this Task. It's going to reply in the same channel the command was sent from with `Pong`
        await ReplyAsync("Pong!");
    }
}
```

Note in the above code, the use of `Async` and `Await` this is because everything in Discord.Net 2.0 uses asynchronous programming. These asynchronous Methods (Like `ReplyAsync`) require we place the word `await` before the call to the method. Read up on Asynchronous Programming Here: [Asynchronous Programming - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)

---

That's it for this part of the guide. If you want to continue this guide where we go into something a tiny bit more advanced, click on one of the links below.

- [Commands With Parameters](WithParameters/)
- [Commands With Advanced Parameters](AdvancedParameters/)
- [Command Grouping](CommandGrouping/)
- [Command Attributes](CommandAttributes/)
- [Commands Using Services](CommandsWithServices/)

If none of the above guides cover your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)
