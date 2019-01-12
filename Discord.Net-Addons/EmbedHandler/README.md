<p align="center">
    <img src="../../Images/EmbedHandler.png">
</p>

# How To Add EmbedHandler To Your Project

**This addon allows you to easily create simple Embeds and can be extended to allow the creation of more complex Embeds as you see fit.**

## How To Add To Your Project

Above you will see a file named [EmbedHandler.cs](EmbedHandler.cs) you can either download that file and add it to your project, or you can copy the raw data directly into a new class in your project.

## How To Setup

```cs
//First you will need to change the namespace to reflect your bot's structure.
//In this example I am placing the EmbedHandler.cs into a folder named Handlers.
//As such the namespace will reflect that.
namespace MyAwesomeBot.Handlers
```

```cs
//Now to actually use it.
//Add a using directive for the handler.
using MyAwesomeBot.Handlers;
```

```cs
//Now you can use the handler by simply invoking the method
//Remember that this handler returns the Embed object.
//Option 1 (Save the embed as a variable to use somewhere in your code):
var myEmbed = await EmbedHandler.CreateBasicEmbed("My Awesome Title", "My Awesome Description", Color.Red);

//Option 2 (Add the embed directly into a ReplyAsync or SendMessageAsync):
await ReplyAsync("", false, await EmbedHandler.CreateBasicEmbed("My Awesome Title", "My Awesome Description", Color.Red));
```

**Note**: The Methods in the class all return the Embed as a Built Object so you don't have to call, ``.Build();``

That's it. If you have any issues using this or just need some help adding to it use the links below to find me on Discord.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)