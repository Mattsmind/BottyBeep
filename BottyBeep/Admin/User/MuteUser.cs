using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace BottyBeep.Admin.User
{
    public class MuteUser : ModuleBase<SocketCommandContext>
    {
        public async Task MuteUserAsync(IGuildUser user)
        {
            //await user.AddRoleAsync(Context.Guild.GetRole("MUTED"));
            await Task.CompletedTask;
        }

        public async Task UnmuteUserAsync(IGuildUser user)
        {
            await Task.CompletedTask;
        }
    }
}
