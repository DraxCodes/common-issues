<p align="center">
    <img src="../Images/Issues.png">
</p>

# Running a Discord.Net bot in a Windows 7 machine
If you're hosting your bot in a Windows 7 machine, you probably faced an error in wich your bot keep disconnecting over and over.

## Why is this happening?
This is caused due to WIndows 7 using a different socket provider than the one Discord.Net uses by default, and those are incompatible.

## How could I fix it?
First, you have to add a nuget package, [`Discord.Net.Providers.WS4Net`](https://www.nuget.org/packages/Discord.Net.Providers.WS4Net/) wich adds support to the Windows 7 web socket provider.

You'd need to modify your `DiscordSocketClient` properties to use the right socket provider. 
Go to where you instantiate your `DiscordSocketClient` (usually in `Program.cs`) and modify the `DiscordSocketConfig` to use a provider compatible with Windows 7. Here's an example of adding this configuration:

```cs

// Your previous code
var discordSocketConfig = new DiscordSocketConfig {
    LogLevel = LogSeverity.Verbose,
    AlwaysDownloadUsers = true,
    MessageCacheSize = 100
};
_client = new DiscordSocketClient(discordSocketConfig);

// New code
var discordSocketConfig = new DiscordSocketConfig {
    LogLevel = LogSeverity.Verbose,
    AlwaysDownloadUsers = true,
    MessageCacheSize = 100,
    WebSocketProvider = WS4NetProvider.Instance
};
_client = new DiscordSocketClient(discordSocketConfig);
```
>Note: You don't have to replace the configuration you had, or modify anything more than the `WebSocketProvider` property, unless you had no configuration.

Remember to import the `Discord.Net.Providers.WS4Net` package with the `using` directive at the top of the file where you instantiate the `DiscordSocketClient`: 
```cs
using Discord.Net.Providers.WS4Net;
```

Author: [Charly#7094](https://github.com/Charly6596)

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)