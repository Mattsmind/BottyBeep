using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Admin.Bot
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [RequireOwner]
        public async Task PingAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();
        
            builder.WithTitle("Ping Reply")
                .WithColor(Color.DarkerGrey)
                .WithDescription($"PONG! **{Context.Client.Latency}ms**");

            await ReplyAsync("", false, builder.Build());
        }
    }
}
