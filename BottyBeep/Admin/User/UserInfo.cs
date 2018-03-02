using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace BottyBeep.Admin.User
{
    public class UserInfo : ModuleBase<SocketCommandContext>
    {
        [RequireUserPermission(GuildPermission.KickMembers)]
        [Command("userinfo")]
        public async Task GetUserInfoAsync(IGuildUser user)
        {
            EmbedBuilder builder = new EmbedBuilder();

            string joinedDate = user.JoinedAt.ToString();
            string username = user.Username;
            string nickname = user.Nickname;
            string userID = user.Id.ToString();
            string userAvatar = user.GetAvatarUrl();

            var userRoles = user.RoleIds;       

            builder.WithTitle("User Information")
                .WithColor(Color.Purple)
                .WithDescription(String.Format("{5}\n**Username**: `{0}`\n**User ID**: {1}\n**Nickname**: `{2}`\n**Joined**: {3}\n**Roles**: {4}", username, userID, nickname, joinedDate, String.Join(", ", userRoles), userAvatar));

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
    }
}
