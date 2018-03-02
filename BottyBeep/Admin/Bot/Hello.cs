using Discord;
using Discord.Commands;
using System;
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
                .WithColor(new Color(0.123f,0.932f,0.0f));

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
    }
}
