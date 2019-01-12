using Discord.Commands;
using Discord.WebSocket;
using Discord;
using System.Threading.Tasks;

namespace Botwyn.Modules
{
    public class CommandAttributes : ModuleBase<SocketCommandContext>
    {
        [Command("Purge"), Summary("Purges a bunch of messages."), RequireOwner]
        public async Task Purge(SocketGuildUser user)
        {
            await ReplyAsync($"PURGE ALL THE THINGS");
        }

        [Command("Kick"), Summary("Kicks a user in the butt."), RequireOwner]
        public async Task Kick([Summary("The User To Kick")]SocketGuildUser user)
        {
            await ReplyAsync($"KICK ALL THE THINGS");
        }

        [Command("Ban"), Summary("Bans a user.")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task Ban([Summary("The User To Ban")]SocketGuildUser user)
        {
            await ReplyAsync($"BAN ALL THE THINGS");
        }
    }
}
