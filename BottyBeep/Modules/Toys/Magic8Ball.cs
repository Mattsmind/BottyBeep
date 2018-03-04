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
                // It is certain
                case 1:
                    result = "It is certain.";
                    break;

                // It is decidedly so
                case 2:
                    result = "It is decidedly so.";
                    break;

                // Without a doubt
                case 3:
                    result = "Without a doubt.";
                    break;

                // Yes definitely
                case 4:
                    result = "Yes definitly.";
                    break;

                // You may rely on it
                case 5:
                    result = "You may rely on it.";
                    break;

                // As I see it, yes
                case 6:
                    result = "As I see it, yes.";
                    break;

                // Most likely
                case 7:
                    result = "Most likely.";
                    break;

                // Outlook good
                case 8:
                    result = "Outlook good.";
                    break;

                // Yep
                case 9:
                    result = "Yep.";
                    break;

                // Signs point to yes
                case 10:
                    result = "Signs point to yes.";
                    break;

                // Reply hazy try again
                case 11:
                    result = "Reply hazy. Try again.";
                    break;

                // Ask again later
                case 12:
                    result = "Ask again later.";
                    break;

                // Better not tell you now
                case 13:
                    result = "Better not tell you now.";
                    break;

                // Cannot predict now
                case 14:
                    result = "Cannot predict now.";
                    break;

                // Concentrate and ask again
                case 15:
                    result = "Concentrate and ask again.";
                    break;

                // Don't count on it
                case 16:
                    result = "Don't count on it.";
                    break;

                // My reply is no
                case 17:
                    result = "My reply is no.";
                    break;

                // My sources say no
                case 18:
                    result = "My sources say no.";
                    break;

                // Outlook not so good
                case 19:
                    result = "Outlook not so good.";
                    break;

                // Very doubtful
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
