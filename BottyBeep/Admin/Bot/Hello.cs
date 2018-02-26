using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Admin.Bot
{
    public class Hello : ModuleBase<SocketCommandContext>
    {
        [Command("hello"), Alias("codebase", "mycode", "code")]
        public async Task HelloAsync()
        {
            string myRepo = "https://github.com/Mattsmind/BottyBeep";
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("My Code Repo")
                .WithDescription(String.Format("Hello, {0}! My code repository is located at {1}", Context.User.Mention, myRepo))
                .WithColor(new Color(123f,110f,0.0f));

            await ReplyAsync("", false, builder.Build());
        }
    }
}
