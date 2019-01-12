using Discord.Commands;
using System.Threading.Tasks;

namespace Botwyn.Modules
{
    public class BasicCommandGuide : ModuleBase<SocketCommandContext>
    {
        [Command("Ping")]
        public async Task Ping()
        {
            await ReplyAsync("Pong!");
        }
    }
}
