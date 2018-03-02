using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace BottyBeep.Admin.Bot
{
    public class Echo : ModuleBase<SocketCommandContext>
    {
        [RequireBotPermission(GuildPermission.SendMessages)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [Command("echo"), Alias("say")]
        public async Task EchoAsync([Remainder]string message)
        {
            await Context.Channel.SendMessageAsync(message);
        }
    }
}
