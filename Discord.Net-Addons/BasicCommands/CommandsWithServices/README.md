<p align="center">
    <img src="../../../Images/CommandsGuide/Services.png">
</p>

# Commands With Services Guide Discord.Net 2.0

### This will cover the basics of setting up your own custom command modules in Discord.Net 2.0

**NOTE This guide is for command modules only. it does not explain how to setup your whole bot**

### Moving On - Commands With Services

This is going to be a super short little guide as Services can basically be anything you want however we're going to go over the most basic kind of service. 

A service is essentially a way of splitting up your bot in a way that makes more sense. What I mean by this is that it's not seen as good practice to have tons of code in your modules these days.

**NOTE: Please bare in mind that is is purely subjective and is intended purely as a guide, this perticular guide will most likley be updated when the Dependecy Injection guide is added as-well. Also Note This is going to be a super simple example, it's up to you to figure out ways to implement this into your bot.**

So how are we going to split up our code into this `Service` & `Module` design?

- To start off with you're going to want to create a new class that is going to be the Service. In this example we're going to create a service that's going to simply handle formatting our input text.
- Im going to start by making a new class named `FormattingService`. Inside this class I am going to create a `static` method that returns a string. We're also going to have the method take two string parameters as-well. See below.

```cs
public static class FormattingService
{
    public static string Format(string name, string address)
    {
    }
}
```

Now because this is a FormattingService we're going to use it as just that.

- So let's format our text a little so it has some extra stuff

```cs
public static class FormattingService
{
    public static string Format(string name, string address)
    {
        var formattedText = $"Your name is: {name}, You live in {city}";
        return formattedText;
    }
}
```

So now we have a super simple formatting service. So lets implement it into our command.

```cs
[Command("Info")]
public async Task Info(string name, string city)
{
    await ReplyAsync(FormattingService.Format(name, city));
}
```

Notice how we're now using our service to do all the formatting for us. It's not only much cleaner but it also allows us to keep things seperated into their own little sections of the bot. If we ever needed to change the way the output is formatted, we'd go to our FormattingService and simply change it there. Then anything in our bot that uses that Service also recieves the updates as it's all coming from our service.

You could even go a step further and use Lambda Expressions for the Command Tasks (Shown Below) to simplify your Module class even more.

```cs
[Command("Info")]
public async Task Info(string name, string city)
    => await ReplyAsync(FormattingService.Format(name, city));
```

---

That's it for this section of the Guide, if you feel like you want to learn more then please use the links below to continue the guides.

- [Commands With Parameters](../WithParameters/)
- [Command Grouping](../CommandGrouping/)
- [Commands With Advanced Parameters](../AdvancedParameters/)
- [Command Attributes](../CommandAttributes/)

If none of the above guides cover your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)