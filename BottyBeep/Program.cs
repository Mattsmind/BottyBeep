using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace BottyBeep
{
    class Program
    {
        static void Main(string[] args) => 
            new Core.Bot().StartAsync().GetAwaiter().GetResult();
    }
}
