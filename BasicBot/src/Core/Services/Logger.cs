using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBot.Core.Services
{
    public class Logger
    {
        public void Log(string msg)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("dd/M HH:mmtt")}] - {msg}");
        }
    }
}
