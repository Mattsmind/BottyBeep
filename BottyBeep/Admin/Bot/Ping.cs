using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace BottyBeep.Admin.Bot
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [RequireBotPermission(GuildPermission.SendMessages)]
        [RequireUserPermission(GuildPermission.Administrator)]
        [Command("ping")]
        public async Task PingAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();
        
            builder.WithTitle("Ping Reply")
                .WithColor(Color.DarkerGrey)
                .WithDescription($"PONG! **{Context.Client.Latency}ms**");

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
    }
}
