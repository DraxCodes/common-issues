using GlobalStatic_ExampleBot.Services;
using System;
using System.Threading.Tasks;

namespace GlobalStatic_ExampleBot
{
    class Program
    {
        static Task Main(string[] args)
            => new DiscordService().InitializeAsync();
    }
}
