using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Botwyn.Modules
{
    [Group("Admin")]
    public class CommandGroups : ModuleBase<SocketCommandContext>
    {
        [Command("purge")]
        public async Task Purge(SocketGuildUser user)
        {
            await ReplyAsync($"PURGE ALL THE THINGS");
        }

        [Command("ban")]
        public async Task Ban(SocketGuildUser user)
        {
            await ReplyAsync($"BAN ALL THE THINGS");
        }

        [Command("kick")]
        public async Task Kick(SocketGuildUser user)
        {
            await ReplyAsync($"KICK ALL THE THINGS");
        }
    }
}
