using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Modules.Toys
{
    public class Magic8Ball : ModuleBase<SocketCommandContext>
    {
        [RequireBotPermission(ChannelPermission.SendMessages)]
        [RequireUserPermission(ChannelPermission.SendMessages)]
        [Command("magic8ball"), Alias("8ball", "m8b")]
        public async Task Magic8BallAsync([Remainder] string question)
        {
            EmbedBuilder builder = new EmbedBuilder();

            int numberOfAnswers = 20;
            Random rnd = new Random();
            int answer = rnd.Next(1, numberOfAnswers + 1);
            string result = "";
            switch (answer)
            {
                //LATER THIS SHOULD BE RECODED TO USE A CONFIG OF SOME SORT
                // case 1 - 5 = yes
                // case 6 - 10 = maybe yes
                // case 11 - 15 = maybe no 
                // case 16 - 20 = no
                // default should never be called.

                case 1:
                    result = "It is certain.";
                    break;

                case 2:
                    result = "It is decidedly so.";
                    break;

                case 3:
                    result = "Without a doubt.";
                    break;

                case 4:
                    result = "Yes definitly.";
                    break;

                case 5:
                    result = "You may rely on it.";
                    break;

                case 6:
                    result = "As I see it, yes.";
                    break;

                case 7:
                    result = "Most likely.";
                    break;

                case 8:
                    result = "Outlook good.";
                    break;

                case 9:
                    result = "Yep.";
                    break;

                case 10:
                    result = "Signs point to yes.";
                    break;

                case 11:
                    result = "Reply hazy. Try again.";
                    break;

                case 12:
                    result = "Ask again later.";
                    break;

                case 13:
                    result = "Better not tell you now.";
                    break;

                case 14:
                    result = "Cannot predict now.";
                    break;

                case 15:
                    result = "Concentrate and ask again.";
                    break;

                case 16:
                    result = "Don't count on it.";
                    break;

                case 17:
                    result = "My reply is no.";
                    break;

                case 18:
                    result = "My sources say no.";
                    break;

                case 19:
                    result = "Outlook not so good.";
                    break;

                case 20:
                    result = "Very doubtful.";
                    break;

                default:
                    result = "Only MrMattsmind knows.";
                    break;

            }

            builder.WithTitle("Magic 8 Ball")
                .WithDescription(String.Format("{0} asks _\"{1}\"_...\n\n**{2}**", Context.User.Mention, question, result))
                .WithColor(Color.Orange);

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
    }
}
