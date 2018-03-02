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
        public async Task BanUserAsync(IGuildUser user, int daysToPurge = 5, [Remainder] string reason = "No Reason Given.")
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("PERM BAN NOTICE")
                .WithDescription(String.Format("_{0} has been permanently banned by {1}_\n**REASON:** {2}", user.Mention, Context.User.Username, reason))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkRed);

            await MessageUserNotice(user, builder);
                       
            await user.Guild.AddBanAsync(user, daysToPurge, reason);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }

        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [Command("tempban"), Alias("ban")]
        public async Task TempBanAsync(IGuildUser user, [Remainder] string reason = "No Reason Given.")
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("BAN NOTICE")
                .WithDescription(String.Format("_{0} has been temporarly banned by **{1}**_\n**REASON:** {2}", user.Mention, Context.User.Username, reason))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkRed);

            await MessageUserNotice(user, builder);

            await user.Guild.AddBanAsync(user, 0, reason);
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }

        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [Command("unban")]
        public async Task UnbanAsync(string user)
        {
            var banlist = await Context.Guild.GetBansAsync();
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("BAN REMOVAL NOTICE")
                .WithDescription(String.Format("_{0} has been unbanned by **{1}**_", user, Context.User.Username))
                .WithCurrentTimestamp()
                .WithColor(Color.DarkRed);

            foreach (var b in banlist)
            {
                if (b.User.Username == user)
                {
                    await Context.Guild.RemoveBanAsync(b.User as IUser);
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                }
            }
        }

        // This probably should go in the Utilities 
        private async Task MessageUserNotice(IGuildUser user, EmbedBuilder builder)
        {
            var msgUser = await user.GetOrCreateDMChannelAsync();
            await msgUser.SendMessageAsync("", false, builder.Build());
            await msgUser.CloseAsync();
        }
    }
}
