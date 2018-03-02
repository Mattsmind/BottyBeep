using Discord;
using System;
using System.Threading.Tasks;

namespace BottyBeep.Core
{
    class LogHandler
    {
        public async Task LogAsync(LogMessage msg)
        {
            if (msg.Exception != null)
            {
                await LogErrorAsync(msg.Exception.Message);
            }
            else
            {
                await LogAsync(msg.Source, msg.Message);
            }
        }

        public async Task LogAsync(string source, string msg)
        {
            source = source.PadRight(15);
            Console.WriteLine("[{0}] {1}{2}", DateTime.Now.ToLongTimeString(), source, msg);
            Console.ResetColor();
            await Task.CompletedTask;
        }

        public async Task LogErrorAsync(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await LogAsync("ERROR", msg);
        }

        public async Task LogCommandsAsync(string user, string command)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            await LogAsync(user, command);
        }
    }
}
