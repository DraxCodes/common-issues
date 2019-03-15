<p align="center">
    <img src="../Images/Issues.png">
</p>

# Using Custom Emojis in a Discord Bot

## What is this

**This will guide you through the several different ways to both find and send Custom Emojis in a Discord.Net or D#+ Bot.**

## How To

Below I will explain how to both find emoji's from a guild or through the client.

### Getting The Emoji By ID

To get an Emoji by ID you can simply put `\` in front of the Custom Emoji itself and it will give you the formatted discord emoji with an ID.

#### Example

* In my test server I have an emoji: `:tips_fedora:` if I place a `\` in front of it like so `\:tips_fedora:` it will give the the formatted way of sending it. `<:tips_fedora:537824544065585152>`
* **NOTE**: If you do this with an animated Emoji, it will also have the key `a` with it like so `<a:bounce:530717524376158208>`. 
* Essentially the formatting is: `<[a if animated]:[name]:[ID]>`

#### Sending Using ID

```cs
await Context.Channel.SendMessageAsync("<:tips_fedora:537824544065585152>");
```

### Emoji via Context.Guild

You can use this method in the case where you want to maybe define an Emoji by name, maybe from a command parameter.

#### Getting the Emoji

```cs
var emoji = Context.Guild.Emotes.FirstOrDefault(x => x.Name == "Name Of Your Emoji Here");
```

#### Sending the Emoji

```cs
await Context.Channel.SendMessageAsync(emoji);
```

#### Possible Usecase

```cs
[Command("emoji")]
public async Task Emoji(string emojiName)
{
    var emoji = Context.Guild.Emotes.FirstOrDefault(x => x.Name == emojiName);
    if (emoji != null)
        await ReplyAsync($"{emoji}");
    else
        await ReplyAsync("Emoji not found,");
        }
```

---

That's it for this guide. If none of the above guide covers your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)
