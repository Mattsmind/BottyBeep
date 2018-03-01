using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Core
{
    class LogHandler
    {
        //constructor?

        //general logger
        public async Task LogAsync(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
            await Task.CompletedTask;
        }

        public async Task LogAsync(string source, string msg)
        {
            
            await Task.CompletedTask;
        }

        //log error message
        public async Task LogErrorAsync()
        {
            await Task.CompletedTask;
        }

        //log commands
        public async Task LogCommandsAsync()
        {
            await Task.CompletedTask;
        }

    }
}
