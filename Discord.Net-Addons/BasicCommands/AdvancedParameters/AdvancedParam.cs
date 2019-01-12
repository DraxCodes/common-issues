using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Botwyn.Modules
{
    public class AdvancedParam : ModuleBase<SocketCommandContext>
    {
        [Command("UserInfo")]
        public async Task UserInfo(SocketGuildUser user)
        {
            await ReplyAsync($"The Users Username is: {user.Username}, They Joined On: {user.JoinedAt}");
        }

        [Command("ChanInfo")]
        public async Task ChanInfo(SocketGuildChannel channel)
        {
            await ReplyAsync($"The channel name is: {channel.Name}, The ID is: {channel.Id}");
        }
    }
}
