<p align="center">
    <img src="../../../Images/CommandsGuide/Grouping.png">
</p>

# Command Grouping Guide Discord.Net 2.0

### This will cover the basics of setting up your own custom command modules in Discord.Net 2.0

**NOTE This guide is for command modules only. it does not explain how to setup your whole bot**

### Moving On - Command Grouping

So What is Command Grouping? Command Grouping is a way of grouping up a bunch of commands. It's a little hard to explain so instead here are some examples.

- Command grouping allways you to group together commands under a single base command for example;
  - Lets say you want a few Admin only commands, you want them as
    - `!admin purge`
    - `!admin ban`
    - `!admin kick`
  - Well without command grouping your commands would end up looking like this in your modules:

```cs
[Command("admin purge")]
public async Task Purge(SocketGuildUser user)
{
    await ReplyAsync($"PURGE ALL THE THINGS");
}

[Command("admin ban")]
public async Task Ban(SocketGuildUser user)
{
    await ReplyAsync($"BAN ALL THE THINGS");
}

[Command("admin kick")]
public async Task Kick(SocketGuildUser user)
{
    await ReplyAsync($"KICK ALL THE THINGS");
}
```

Now many people may be ok with that sort of setup. It works but it's not always the best way to go about it. What if you want to change the commands name slightly from `!admin` to `!owner`, well with the above setup, you'd have to go through each command changing it manually (It's a pain and a bad setup). Command grouping allows us to go back to how we know to create commands in our modules but places them under one overall command. In this case it will be `!admin`. Here is an example of command grouping.

```cs
[Group("Admin")]
public class CommandGroups : ModuleBase<SocketCommandContext>
{
    [Command("purge")]
    public async Task Purge(SocketGuildUser user)
    {
        await ReplyAsync($"PURGE ALL THE THINGS");
    }

    [Command("ban")]
    public async Task Ban(SocketGuildUser user)
    {
        await ReplyAsync($"BAN ALL THE THINGS");
    }

    [Command("kick")]
    public async Task Kick(SocketGuildUser user)
    {
        await ReplyAsync($"KICK ALL THE THINGS");
    }
}
```

Notice how we have just got a normal Module like any other, with normal command inside it. However this time the slight difference is, we have the attribute `[Group("Admin")]` on top of our Module Class.

All this does is tell the CommandService that the command in this module are part of a group, this in turns changes how the commands are structured for use in discord. The command in this new group can now be ran like:

- `!admin purge`
- `!admin ban`
- `!admin kick`

So now we don't have to mess around making sure all the commands in the module have the word `admin` in the command name. Instead Discord.Net does it for us.

---

That's it for this section of the Guide, if you feel like you want to learn more then please use the links below to continue the guides.

- [Commands With Parameters](../WithParameters/)
- [Commands Using Services](../CommandsWithServices/)
- [Commands With Advanced Parameters](../AdvancedParameters/)
- [Command Attributes](../CommandAttributes/)

If none of the above guides cover your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)