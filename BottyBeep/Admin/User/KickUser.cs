using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace BottyBeep.Admin.User
{
    public class KickUser : ModuleBase<SocketCommandContext>
    {
        [RequireBotPermission(GuildPermission.KickMembers)]
        [RequireUserPermission(GuildPermission.KickMembers)]
        [Command("kick")]
        public async Task KickUserAsync(IGuildUser user, [Remainder] string reason = "No reason given.")
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("KICK NOTICE")
                .WithDescription(String.Format("___{0} has been kicked by {1}___\n**REASON:** {2}", user.Mention, Context.User.Username, reason))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkRed);

            await user.KickAsync(reason);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
    }
}
