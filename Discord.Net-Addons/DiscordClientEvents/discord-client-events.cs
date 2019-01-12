// ======================================================
// This file is taken from the old CommunityBot project
// It demonstrates subscribing to all Discord.NET client
// events along with their method signatures.
// ======================================================

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace MyAwesomeBot.Handlers
{
    /// <summary>
    /// Put your subscriptions to events here!
    /// Just one non awaited async Method per functionality you want to provide 
    /// </summary>
    public class DiscordEventHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandHandler _commandHandler;

        public DiscordEventHandler(DiscordSocketClient client, CommandHandler commandHandler)
        {
            _client = client;
            _commandHandler = commandHandler;
        }

        public void InitDiscordEvents()
        {
            _client.ChannelCreated += ChannelCreated;
            _client.ChannelDestroyed += ChannelDestroyed;
            _client.ChannelUpdated += ChannelUpdated;
            _client.Connected += Connected;
            _client.CurrentUserUpdated += CurrentUserUpdated;
            _client.Disconnected += Disconnected;
            _client.GuildAvailable += GuildAvailable;
            _client.GuildMembersDownloaded += GuildMembersDownloaded;
            _client.GuildMemberUpdated += GuildMemberUpdated;
            _client.GuildUnavailable += GuildUnavailable;
            _client.GuildUpdated += GuildUpdated;
            _client.JoinedGuild += JoinedGuild;
            _client.LatencyUpdated += LatencyUpdated;
            _client.LeftGuild += LeftGuild;
            _client.Log += Log;
            _client.LoggedIn += LoggedIn;
            _client.LoggedOut += LoggedOut;
            _client.MessageDeleted += MessageDeleted;
            _client.MessageReceived += MessageReceived;
            _client.MessageUpdated += MessageUpdated;
            _client.ReactionAdded += ReactionAdded;
            _client.ReactionRemoved += ReactionRemoved;
            _client.ReactionsCleared += ReactionsCleared;
            _client.Ready += Ready;
            _client.RecipientAdded += RecipientAdded;
            _client.RecipientRemoved += RecipientRemoved;
            _client.RoleCreated += RoleCreated;
            _client.RoleDeleted += RoleDeleted;
            _client.RoleUpdated += RoleUpdated;
            _client.UserBanned += UserBanned;
            _client.UserIsTyping += UserIsTyping;
            _client.UserJoined += UserJoined;
            _client.UserLeft += UserLeft;
            _client.UserUnbanned += UserUnbanned;
            _client.UserUpdated += UserUpdated;
            _client.UserVoiceStateUpdated += UserVoiceStateUpdated;
        }

        private async Task ChannelCreated(SocketChannel channel)
        {
            
        }

        private async Task ChannelDestroyed(SocketChannel channel)
        {
            
        }

        private async Task ChannelUpdated(SocketChannel channelBefore, SocketChannel channelAfter)
        {
            
        }

        private async Task Connected()
        {
            
        }

        private async Task CurrentUserUpdated(SocketSelfUser userBefore, SocketSelfUser userAfter)
        {
            
        }

        private async Task Disconnected(Exception exception)
        {
            
        }

        private async Task GuildAvailable(SocketGuild guild)
        {
            
        }

        private async Task GuildMembersDownloaded(SocketGuild guild)
        {
            
        }

        private async Task GuildMemberUpdated(SocketGuildUser userBefore, SocketGuildUser userAfter)
        {
            
        }

        private async Task GuildUnavailable(SocketGuild guild)
        {
            
        }

        private async Task GuildUpdated(SocketGuild guildBefore, SocketGuild guildAfter)
        {
            
        }

        private async Task JoinedGuild(SocketGuild guild)
        {

        }

        private async Task LatencyUpdated(int latencyBefore, int latencyAfter)
        {
            
        }

        private async Task LeftGuild(SocketGuild guild)
        {
            
        }

        private async Task Log(LogMessage logMessage)
        {
            
        }

        private async Task LoggedIn()
        {
            
        }

        private async Task LoggedOut()
        {
            
        }

        private async Task MessageDeleted(Cacheable<IMessage, ulong> cacheMessage, ISocketMessageChannel channel)
        {
            
        }

        private async Task MessageReceived(SocketMessage message)
        {

        }

        private async Task MessageUpdated(Cacheable<IMessage, ulong> cacheMessageBefore, SocketMessage messageAfter, ISocketMessageChannel channel)
        {
            
        }

        private async Task ReactionAdded(Cacheable<IUserMessage, ulong> cacheMessage, ISocketMessageChannel channel, SocketReaction reaction)
        {

        }

        private async Task ReactionRemoved(Cacheable<IUserMessage, ulong> cacheMessage, ISocketMessageChannel channel, SocketReaction reaction)
        {
            
        }

        private async Task ReactionsCleared(Cacheable<IUserMessage, ulong> cacheMessage, ISocketMessageChannel channel)
        {
            
        }

        private async Task Ready()
        {

        }

        private async Task RecipientAdded(SocketGroupUser user)
        {
            
        }

        private async Task RecipientRemoved(SocketGroupUser user)
        {
            
        }

        private async Task RoleCreated(SocketRole role)
        {
            
        }

        private async Task RoleDeleted(SocketRole role)
        {
            
        }

        private async Task RoleUpdated(SocketRole roleBefore, SocketRole roleAfter)
        {
            
        }

        private async Task UserBanned(SocketUser user, SocketGuild guild)
        {
            
        }

        private async Task UserIsTyping(SocketUser user, ISocketMessageChannel channel)
        {
            
        }

        private async Task UserJoined(SocketGuildUser user)
        {

        }

        private async Task UserLeft(SocketGuildUser user)
        {

        }

        private async Task UserUnbanned(SocketUser user, SocketGuild guild)
        {
            
        }

        private async Task UserUpdated(SocketUser oldUser, SocketUser newUser)
        {
            
        }

        private async Task UserVoiceStateUpdated(SocketUser user, SocketVoiceState voiceStateBefore, SocketVoiceState voiceStateAfter)
        {
            
        }
    }
}
