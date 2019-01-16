using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBot.Entities
{ 
    //This is the structure of our Config.json file.
    public class BotConfig
    {
        public string DiscordToken { get; set; }
        public string GameStatus { get; set; }
    }
}
