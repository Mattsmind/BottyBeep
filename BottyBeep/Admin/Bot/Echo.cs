using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Admin.Bot
{
    public class Echo : ModuleBase<SocketCommandContext>
    {
        [Command("echo"), Alias("say")]
        public async Task EchoAsync([Remainder]string message)
        {
            await ReplyAsync(message);
        }
    }
}
