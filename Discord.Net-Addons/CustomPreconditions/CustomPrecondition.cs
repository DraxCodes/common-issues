using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace MyAwesomeBot.Preconditions
{
    public class RequireSpecificGuild : PreconditionAttribute
    {
        //your variables
        private ulong _guildId;        
        
        // Here you define the parameters your precondition will have
        // In this case, you could do [RequireSpecificGuild(412454355435)]
        // It's not recommended to hardcode Ids, but it's an example (:
        public RequireSpecificGuild(ulong guildId)
        {
           _guildId = guildId;
        }
        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            if(context.Guild.Id != _guildId)
            {
                //Your command handler will get an error with this message
                return Task.FromResult(PreconditionResult.FromError($"You can't use this command in this guild."));
            }
            else
            {
                //Command wil execute
                return Task.FromResult(PreconditionResult.FromSuccess());
            }
        }
    }
}
