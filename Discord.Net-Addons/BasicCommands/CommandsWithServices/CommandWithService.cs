using Discord.Commands;
using Discord.WebSocket;
using Discord;
using System.Threading.Tasks;

namespace Botwyn.Modules
{
    public class CommandWithService : ModuleBase<SocketCommandContext>
    {
        [Command("Info")]
        public async Task Info(string name, string city)
        {
            await ReplyAsync(FormattingService.Format(name, city));
        }

        [Command("Info")]
        public async Task Info(string name, string city)
            => await ReplyAsync(FormattingService.Format(name, city));
    }
}
