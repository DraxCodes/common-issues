using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalStatic_ExampleBot.Services
{
    public static class Global
    {
        public static DiscordSocketClient Client { get; set; }
        public static CommandService CmdService { get; set; }
        public static ulong TestChannel { get; set; } = 513467883825922063;
    }
}
