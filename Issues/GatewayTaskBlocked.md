<p align="center">
    <img src="../Images/Issues.png">
</p>

# A MessageReceived handler is blocking the gateway task
If you're dealing with Discord events, or just making a cool and fancy command, you might see a warning in your console, with a message similar to `A MessageReceived handler is blocking the gateway task`. 

## What's the reason behind that?
This is caused due to our command or event handler taking more than 3 seconds to complete an action. Having the gateway blocked, means our bot can't send/receive any response using events, and, after all, our bot behavior is heavily based on events.

## Oh, I see, how could I fix that?
The fast answer is, running whatever we're running asynchronously. To achieve that. To achieve that, we have to not `await` heavy actions in any method wich is subscribed to an event -- Commands are subscribed to the MessageReceived event. But we want to be able to run some `Task`s synchronously, don't we?

I'll show you how to do that, in both cases, in commands and events, without blocking the gateway.

### Running a method asynchronously in an event
So, take a look at this example:
Let's assume the `UserJoined` method is subscribed to the `DiscordSocketClient#UserJoined` event, and `WelcomeChannel` is a `SocketTextChannel`:
```cs
internal async Task UserJoined(SocketUser user)
{
    await Task.Delay(5000);
    await WelcomeChannel.SendMessageAsync($"Welcome {user.Mention}!!");
}
```
Our bot would welcome, after 5 seconds, every new user that joins a server in wich our bot is in... Right?

Actually, no, not every new user, what if another user joins within the next 5 seconds, before the last user is welcomed? They won't be welcomed. Our bot won't even notice a new user joined. The gateway is blocked by this line `await Task.Delay(5000);`. 

As I mentioned before, there's a solution for this. Running _whatever we're running_ **asynchronously**.
```cs
internal async Task UserJoined(SocketUser user)
{
    var message = $"Welcome {user.Mention}!!";
    var delay = 10;
    _ = SendDelayedMessageAsync(WelcomeMessage ,message, delay);
}

private async Task SendDelayedMessageAsync(SocketTextChannel channel, string message, ulong delayInSeconds)
{
    var milliseconds = dalayInSeconds * 1000;
    await Task.Delay(milliseconds);
    await channel.SendMessageAsync(message);
}
```
This wouldn't block the gateway! Every new user would be welcomed after five seconds, with no exceptions! (assuming no network issues).
This workaround can be applied to every `DiscordSocketClient` event, it's cool, isn't it?!

### Running a command asynchronously
Sometimes it's just a command that performs an API request (wich usually takes over 3 seconds) what is blocking our gateway.
For example,
```cs
[Command("weather")]
public async Task DisplayWeatherInfo(string city)
{
    var url = $"http://CoolWeatherAPI.net/?city={city}";

    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage message = await client.GetAsync(url);
        message.EnsureSuccessStatusCode();
        var json = await message.Content.ReadAsStringAsync();
        var data = JsonConvert.Deserialize(data);
    }
    var embed = GenerateWeatherEmbed(data);
    await Context.Channel.SendMessageAsync(embed);
}
```
Alright, this is a simple API call, to what seems to be a weather API. This could take over 3 seconds and block our gateway. In the case of commands, we don't need to extract our _heavy action_ to another method to do the trick. There's an argument in the `Command` attribute to run it asynchronously!
```cs
[Command("weather", RunMode = RunMode.Async)]
public async Task DisplayWeatherInfo(string city)
{
    // Omitted code.
}
```
And that's it! As simple as that. Our command will run asynchronously without blocking the gateway, while keeping it's own 
_synchrony_.


Author: [Charly#7094](https://github.com/Charly6596)

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)