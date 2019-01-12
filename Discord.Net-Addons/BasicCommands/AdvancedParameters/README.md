<p align="center">
    <img src="../../../Images/CommandsGuide/AdvancedParameters.png">
</p>

# Advanced Commands Parameters Guide Discord.Net 2.0

### This will cover the basics of setting up your own custom command modules in Discord.Net 2.0

**NOTE This guide is for command modules only. it does not explain how to setup your whole bot**

### Moving On - Commands With Advanced Parameters

So what are Advanced Parameters? Advanved parameters are the types of discord parameters that store more data than just a `string` or `int`. The two I will cover in this example are `SocketGuildUser` & `SocketGuildChannel`.

In this first example we have a `SocketGuildUser` parameter.

```cs
[Command("UserInfo")]
public async Task UserInfo(SocketGuildUser user)
{
    await ReplyAsync($"The Users Username is: {user.Username}, They Joined On: {user.JoinedAt}");
}
```

- What is a `SocketGuildUser`?
  - Well a socket guild user is essentially the user object when you do `@someone` in discord. In our example above, the command is designed to be used as: `!userinfo @Draxis#0359` (The `SocketGuildUser` parameter is `@Draxis#0359`) Now the Discord.Net lib is very clever when it sees this type of parameter, essentially it see's that you're referencing a user that is in the same guild the command was run from and it very quickly grabs a load of information about that user. Their Username, when the joined, when the account was created, the roles they have, etc.
- How is this useful?
  - Well this allows you to do some cool things, as you can see in the code below, we're able to access more properties from inside the `SocketGuildUser` object and use them in our `ReplyAsync` method.

```cs
await ReplyAsync($"The Users Username is: {user.Username}, They Joined On: {user.JoinedAt}");
```

The same thing can be done for a `SocketGuildChannel`. This is the object that is created when you do `#ChannelName`. In the below example the command is designed to be ran as: `!chaninfo #MyAwesomeChannel`.

```cs
[Command("ChanInfo")]
public async Task ChanInfo(SocketGuildChannel channel)
{
    await ReplyAsync($"The channel name is: {channel.Name}, The ID is: {channel.Id}");
}
```

As you can see we're using property values from inside the `SocketGuildChannel` object to display info about the channel. In this case it's the Channel Name and the Channel ID.

These Types of parameters are very good to know about as they're how you create more advanced commands like `!ban & !kick`. The `SocketGuildChannel` can be used in a blacklist command where you could say `!blacklist #MyAwesomeChannel` at which point you may have it so commands are no longer allowed to be ran in that channel.

---

That's it for this section of the Guide, if you feel like you want to learn more then please use the links below to continue the guides.

- [Commands With Parameters](../WithParameters/)
- [Commands Using Services](../CommandsWithServices/)
- [Command Grouping](../CommandGrouping/)
- [Command Attributes](../CommandAttributes/)

If none of the above guides cover your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)