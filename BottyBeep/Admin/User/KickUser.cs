using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Admin.User
{
    public class KickUser : ModuleBase<SocketCommandContext>
    {
        [RequireBotPermission(GuildPermission.KickMembers)]
        [RequireUserPermission(GuildPermission.KickMembers)]
        [Command("kick")]
        public async Task KickUserAsync(IGuildUser user, string reason = "No reason given.")
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("PERM BAN NOTICE")
                .WithDescription(String.Format("___**{0} has been kicked by {1}**___\n**REASON:** {2}", user.Mention, Context.User.Username, reason))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkRed);

            await user.KickAsync(reason);
        }
    }
}
