using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace BottyBeep.Admin.User
{
    public class GetBans : ModuleBase<SocketCommandContext>
    {
        [Command("getbans")]
        public async Task GetBansAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            var banlist = await Context.Guild.GetBansAsync();

            string result = "";

            foreach (var b in banlist)
            {
                result += b.User.Username + "\n";
            }

            builder.WithTitle("Ban List")
                .WithDescription(result);

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
    }
}
