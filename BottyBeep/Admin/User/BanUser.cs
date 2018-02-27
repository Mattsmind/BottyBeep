using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Admin.Server
{
    public class BanUser : ModuleBase<SocketCommandContext>
    {
        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [Command("permban")]
        public async Task BanUserAsync(IGuildUser user, string reason = "No Reason Given.")
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("PERM BAN NOTICE")
                .WithDescription(String.Format("___**{0} has been permanently banned by {1}**___\n**REASON:** {2}", user.Mention, Context.User.Username, reason))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkRed);
                       
            await user.Guild.AddBanAsync(user, 5, reason);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }

        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [Command("tempban")]
        public async Task TempBanAsync(IGuildUser user, string reason)
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("BAN NOTICE")
                .WithDescription(String.Format("___**{0} has been temporarly banned by {1}**___\n**REASON:** {2}", user.Mention, Context.User.Username, reason))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkRed);

            await user.Guild.AddBanAsync(user, 0, reason);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }

        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [Command("unban")]
        public async Task UnbanAsync(IGuildUser user)
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("BAN REMOVAL NOTICE")
                .WithDescription(String.Format("___**{0} has been unbanned by {1}**___", user.Mention, Context.User.Username))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkRed);

            await user.Guild.RemoveBanAsync(user);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
    }
}
