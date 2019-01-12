<p align="center">
    <img src="../../../Images/CommandsGuide/Parameters.png">
</p>

# Commands With Parameters Guide Discord.Net 2.0

### This will cover the basics of setting up your own custom command modules in Discord.Net 2.0

**NOTE This guide is for command modules only. it does not explain how to setup your whole bot**

### Moving On - Commands With Parameters

Command parameters are essentially a way for you to give your bot more data to use in a Task when it is called. In this guide we're going to cover command parameters by making a nice simple `!say` command. This command is going to be used as shown below and is going to take a parameter called `text`.

- User: !say Hello Everyone!
  - Bot: You said: Hello Everyone!

**NOTE: If you're unsure how commands are supposed to be structured, go back to the Basics Guide [HERE](../).**

This is going to be our overall command

```cs
[Command("say")]
public async Task Say([Remainder]string text)
{
    await ReplyAsync($"You said: {text}");
}
```

Now as you can see we have two new additions to the command compared to the Basic Command Guide (Which was !ping), We have `string text` and also the attribute `[Remainder]`.

- `string text`
  - This is acutally our parameter we're giving our Task. This parameter is just like any other you have have used it the past. It has a Type `string` and a name `text`. Essentially this tells the CommandService that for this command, we don't only need the command itself `!say` but also some extra info too. In this case it's the text we want the bot to reply back to us with.
- `[Remainder]`
  - This is what is called an attribute, you can read up more on them here [Command Attributes](../CommandAttributes/). Essentially this attribute lets us take all the text after the command `!say` and save it in the variable `text`. The reason this Attribute is important is because without it, if we did the command `!say Hello World!` it would only reply with `You said: Hello`. This is because by default the command handler splits up what we type after a command by spaces, so by default our command is split up like so;
    - The command itself: `!say`
    - The First Parameter: `Hello`
    - The Seccond Parameter: `World!`
  - Now for our usecase, we don't want that, we want to split up our command into only two section;
    - The command itself: `!say`
    - The First Parameter: `Hello World!`
  - This Attribute lets us do that.

Now you're not always going to want to use the attribute `[Remainder]`. In the example below we have a command that takes two different `string` parameters.

```cs
[Command("Test")]
public async Task Test(string name, string town)
{
    await ReplyAsync($"Your name is: {name}, You live in: {town}");
}
```

- Usage:
  - Command: `!test Draxis Sheffield`
  - Reply: `Your name is: Draxis, You live in Sheffield`

As you can see in the above example, we're not using the `[Remainder]` attribute as we don't need it. Instead we're taking both parameters (In this case `Draxis` & `Sheffield` and using them in our code).

---

That's it for this section of the Guide, if you feel like you want to learn more then please use the links below to continue the guides.

- [Commands With Advanced Parameters](../AdvancedParameters/)
- [Commands Using Services](../CommandsWithServices/)
- [Command Grouping](../CommandGrouping/)
- [Command Attributes](../CommandAttributes/)

If none of the above guides cover your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)
