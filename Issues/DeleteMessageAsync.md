<p align="center">
    <img src="../Images/Issues.png">
</p>

# DeleteMessageAsync()

## What is it

DeleteMessageAsync is a method you can use to (as the name says) deletes messaged for you.

## How to use it

You can use this method in a few ways.

### First Example

This example allows you to delete the users message when they use a command. For example, if the user used a command like `!say Hello Everyone` it would first delete that users message, then run the command as normal.

```cs
//This way works on the fact that Context.Message is the users message when they use a command.
await Context.Message.DeleteAsync();
```

### Second Example

This Example would be used when you're trying to retrieve a message and delete it. In this case we're going to simplify it by only getting the 5 very last messages sent in the channel.

```cs
//Get The last 5 messages from the channel
var message = Context.Channel.GetMessagesAsync(5).FlattenAsync();
//Delete all of the past 5 messages.
foreach (var msg in pastMessages.Result)
{
        await msg.DeleteAsync();
}
```

Or as an alternative to that, we can be more specific with the messages we delete from the 5 we get.

```cs
//Get the last 5 messages sent in the channel. (Same as before)
var pastMessages = Context.Channel.GetMessagesAsync(5).FlattenAsync();
//Look through the messages to check if they contain a "bad word"
var userMessage = pastMessages.Result.FirstOrDefault(m =>
            m.Content.Contains("SOME BAD WORD"));
//Delete that message.
await userMessage?.DeleteAsync();
```

### More Complex Example

Now you have a basic idea you could also extend this idea to make a Purge command (otherwise known as a clear command). You could specify how many messages you want it delete and have the bot remove that amount of messages from the channel.

```cs
[Command("Purge")]
public async Task PurgeMessages(string ammount)
{
    if (!int.TryParse(ammount, out var num))
    {
        await ReplyAsync("You have to eneter a number to purge.");
    }
    else
    {
        var pastMessages = Context.Channel.GetMessagesAsync(num).FlattenAsync().Result;
        foreach (var msg in pastMessages)
        {
            await msg.DeleteAsync();
        }
        var reply = await ReplyAsync("The Messages Have been pruged!");
        await Task.Delay(4000);
        await reply.DeleteAsync();
    }
}
```

---

That's it for this guide. If none of the above guide covers your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)
