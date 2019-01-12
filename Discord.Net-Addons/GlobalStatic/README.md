<p align="center">
    <img src="../../Images/GlobalStatic.png">
</p>

# How to use a Global Static class to handle your Client & CommandService (Instead of Using Dependency Injection)

_**Note: While this is a valid way to structure your Discord Bot, it is not the ideal way you want to go about it. Idealy you want to be using Dependency Injection To handle your Client & CommandService as-well as any other Concrete Class Services or Services in general.**_

## What is a Global Static Class

A Global Static Class is essentially going to be a class that is always available to you throughout your whole project. It will contain your Client & CommandService so you can access these Objects from anywhere in your project.

## What are the downsides to this

Without going into too much detail, the downsides are completely negligible. This is just not considered "Best Practice" as something like Dependency Injection can do what we're about to do, but better.

## How To Setup

In this guide, I am going to assume you already have a bot setup. If you don't have one setup, you may be better first setting up your first bot using the guide here: [Getting Started - Your First Bot](https://docs.stillu.cc/guides/getting_started/first-bot.html)

Currently you should have an `InitializeAsync()` method that looks something like this

<p align="center">
    <img src="https://i.gyazo.com/d097a5d2e39a6211488358feabd17f23.png">
</p>

Yours may look slightly different but the things we're interested in here are

- `private DiscordSocketClient _client;`
- `private CommandService _commandService;`

### Setting Up Our Static Properties

The goal of this guide is to swap the currently Private Variables (above) to something public and static, that we can use throughout our whole bot.

To do this we're going to first create a new class file in our project and we will name it `Global.cs`. If you're using Visual Studio 2017 it should create something like this for you.

**Note: If it doesn't, just use the below example to create the new class.**

```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalStatic_ExampleBot
{
    class Global
    {

    }
}
```

Now let's modify it a little to make it Public and Static. You only have to change the class, nothing else.

```cs
public static class Global
{

}
```

Now we have the Global Static Class, we're going to add some properties to it that we can use throughout our whole bot. These properties are going to be

- `CommandService`
- `DiscordSocketClient`

**Note: In the below code I add the word `static` to all the properties.**

```cs
public static class Global
{
    public static DiscordSocketClient Client { get; set; }
    public static CommandService CmdService { get; set; }
}
```

So now we have our static properties (Think of them as Static Variables) we can start to use them in our code.

### Using Our New Static Properties

This is probably the most simple part of the whole guide. All we have to do now is swap any instances of our `DiscordSocketClient` & `CommandService` to our new global properties. We'll start in the main `InitializeAsync`.

Because we already have a private _client and _commandService (See above). The best thing to do in this file is to simple assign our private `DiscordSocketClient` & `CommandService` to the Global Static Ones.

To do this we're going to first have to set the initialization of our `new DiscordSocketClient` & `new CommandService` to the `Global.Client` & `Global.CmdService` respectively.

```cs
Global.Client = new DiscordSocketClient();
Global.CmdService = new CommandService();
```

Next we can set our Private `DiscordSocketClient` and `CommandService` to the Global Static Ones

```cs
_client = Global.Client;
_commandService = Global.CmdService;
```

Now you have that done, you should be good to go again. Your bot will function as it did before and you now have a Global Static Client & CommandService.

If you have any issues with something, check out the included example here: [Example Bot Using Global Static Properties](ExampleBot/)

**Note:** You can extend the Global Class you now have to include whatever you may like. Maybe you want to include some Static Channel ID's, will you can. Just add a new property to your Global Class as shown below and you can use those values throughout your whole bot.

```cs
public static class Global
{
    public static DiscordSocketClient Client { get; set; }
    public static CommandService CmdService { get; set; }
    public static ulong TestChannel { get; set; } = 513467883825922063;
}
```

**Note: How you can also assign values to your static properties directly in the class itself too.**

### **IMPORTANT NOTE**

_**I just want to stress the fact that, while this guide of using a Static Global Class to handle your Client, CommandService and other things is super simple, it is not the best way to go about it. We will soon have a Dependency Injection Guide (Link To Follow Shortly) that will explain how to do all this but in a nicer way.**_

---

That's it for this guide. If none of the above guide covers your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)
