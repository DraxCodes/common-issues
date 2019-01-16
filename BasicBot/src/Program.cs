using BasicBot.Core;
using System.Threading.Tasks;

namespace BasicBot
{
    class Program
    {
        static Task Main(string[] args)
            => new BasicBotClient().InitializeAsync();
    }
}
