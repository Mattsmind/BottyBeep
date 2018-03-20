using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Admin.Bot
{
    public class BotNick : ModuleBase<SocketCommandContext>
    {
        [RequireOwner]
        [Command("botnick")]
        public async Task ChangeBotNickAsync(string _nick = "")
        {
            await Context.Guild.CurrentUser.ModifyAsync(nick =>
            {
                nick.Nickname = _nick;
            });
        }
    }
}
