using Discord.WebSocket;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using System;

namespace GlobalStatic_ExampleBot.Services
{
    public class DiscordService
    {
        private DiscordSocketClient _client;
        private CommandService _commandService;

        public async Task InitializeAsync()
        {
            Global.Client = new DiscordSocketClient();
            Global.CmdService = new CommandService();

            _client = Global.Client;
            _commandService = Global.CmdService;

            _client.Log += _client_Log;
            _client.Ready += _client_ReadyAsync;

            await _client.LoginAsync(TokenType.Bot, "YOUR TOKEN HERE");
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task _client_ReadyAsync()
        {
            await new CommandHandler(_client, _commandService).InstallCommandsAsync();
        }

        private Task _client_Log(LogMessage log)
        {
            Console.WriteLine(log.Message);
            return Task.CompletedTask;
        }
    }
}
