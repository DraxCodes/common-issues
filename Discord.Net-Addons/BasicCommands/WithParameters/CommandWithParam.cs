using Discord.Commands;
using System.Threading.Tasks;

namespace Botwyn.Modules
{
    public class CommandWithParam : ModuleBase<SocketCommandContext>
    {
        [Command("Say")]
        public async Task Say([Remainder]string text)
        {
            await ReplyAsync($"You said: {text}");
        }

        [Command("Test")]
        public async Task Test(string name, string town)
        {
            await ReplyAsync($"Your name is: {name}, You live in: {town}");
        }
    }
}
