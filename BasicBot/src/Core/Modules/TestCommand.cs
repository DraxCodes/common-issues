using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasicBot.Core.Modules
{
    public class TestCommand : ModuleBase<SocketCommandContext>
    {
        //Basic Echo Command (Sends whatever the user types after "echo" back into the channel.
        [Command("Echo")]
        public async Task Echo([Remainder]string message)
        {
            await Context.Message.DeleteAsync();
            await ReplyAsync(message);
        }

        //Basic Hello World command but implementing an embed.
        [Command("Hello")]
        public async Task Hello()
        {
            var embed = new EmbedBuilder()
                .WithAuthor(Context.Message.Author)
                .WithColor(Color.Blue)
                .WithTitle("Hello World Command Example")
                .WithDescription($"Hello World and {Context.Message.Author}.");
            await ReplyAsync("", false, embed.Build());
        }
    }
}
