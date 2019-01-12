<p align="center">
    <img src="../../../Images/CommandsGuide/Attributes.png">
</p>

# Advanced Commands Parameters Guide Discord.Net 2.0

### This will cover the basics of setting up your own custom command modules in Discord.Net 2.0

**NOTE This guide is for command modules only. it does not explain how to setup your whole bot**

### Moving On - Commands Attributes

Command Attributes are super cool. They allow you to set information about commands or parameters. You can use them to Require certain permisions to be ran. You can even create your own custom ones (Info At The Bottom).

- **Bot how do they work?**
  - Essentially command attributes work in many different ways so I'm not going to cover what they do in the background. However I will cover what they do for your commands.

Here is a super basic example using command attributes

```cs
[Command("Purge"), Summary("Purges a bunch of messages."), RequireOwner]
public async Task Purge(SocketGuildUser user)
{
    await ReplyAsync($"PURGE ALL THE THINGS");
}
```

As you can see we have these new magical additions compared to the other examples in the other guides. Mainly ``Summary("")`` and ``RequireOwner``.

- `Summary`
  - This allows you to add a summary of what the command does. This summary can then be used in things like help commands to display information to the user about what the command is or what it does.
- `RequireOwner`
  - This is a slightly different Attribute in that instead of adding information to the command, it's instead setting a limitation for the command. In this case it's one that requires the user, using the command, be the owner of the bot.

Command attributes can also be used elsewhere in the your command as-well, have a look at the example below.

```cs
[Command("Kick"), Summary("Kicks a user in the butt."), RequireOwner]
public async Task Kick([Summary("The User To Kick")]SocketGuildUser user)
{
    await ReplyAsync($"KICK ALL THE THINGS");
}
```

As you can see, we have now added a `Summary` attribute to the paramater within our command Task as-well. This works in nearly the identicle way to the Summary for the overall command. The only difference is that this summary is applied to the parameter of the command rather than to the command itself. This can be incredibly useful again for creating help commands with detailed information.

We can also however go a step further than the example with the `RequireOwner` attribute. Take a look at the example below.

```cs
[Command("Ban"), Summary("Bans a user.")]
[RequireUserPermission(GuildPermission.BanMembers)]
public async Task Ban([Summary("The User To Ban")]SocketGuildUser user)
{
    await ReplyAsync($"BAN ALL THE THINGS");
}
```

As you can see, we have now added a new attribute named `RequireUserPermission` and we have given it a parameter of `GuildPermission.BanMembers`. Essentially this is securing our command for us. We know that this command is going to be used to ban people. So ideally we don't want everyone using it. By applying this attribute we lock it down so that only people with the GuildPermission to BanMemembers has the ability to use it.

There are many different attributes available to use for your commands (Way too many to list) so my advise to you would be to take a look with intellisense at all the avilable options.

---

That's it for this part of the guide. If you want to continue this guide where we go into something a tiny bit more advanced, click on one of the links below.

- [Commands With Parameters](../WithParameters/)
- [Commands With Advanced Parameters](../AdvancedParameters/)
- [Command Grouping](../CommandGrouping/)
- [Commands Using Services](../CommandsWithServices/)

If you want to read up on how to create your own custom attributes. Have a read through the link below. (**Note It only covers custom Preconditions**)

- [Custom Command Attributes](../../CustomPreconditions)

If none of the above guides cover your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)