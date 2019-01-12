using Discord.Commands;
using System.Threading.Tasks;
using GlobalStatic_ExampleBot.Services;

namespace GlobalStatic_ExampleBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
            => await ReplyAsync($"{Global.Client.Latency}");
    }
}
