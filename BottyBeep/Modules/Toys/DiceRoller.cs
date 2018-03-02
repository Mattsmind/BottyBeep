using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Modules.Toys
{
    public class DiceRoller : ModuleBase<SocketCommandContext>
    {
        [RequireBotPermission(ChannelPermission.SendMessages)]
        [RequireUserPermission(ChannelPermission.SendMessages)]
        [Command("diceroller"), Alias("dice", "roll")]
        public async Task DiceRollerAsync(string arg = "1d6")
        {
            EmbedBuilder builder = new EmbedBuilder();

            string[] split = arg.Split("d", StringSplitOptions.RemoveEmptyEntries);

            if (split.Length != 2) return;

            int numOfDice = Convert.ToInt32(split[0]);
            int numSides = Convert.ToInt32(split[1]);

            int[] rolls = new int[numOfDice];

            for (int die = 0; die < rolls.Length; die++)
            {
                Random rnd = new Random();
                int roll = rnd.Next(1, numSides + 1);

                rolls[die] = roll;
            }

            int total = 0;
            foreach (int num in rolls)
            {
                total += num;
            }

            var rollingUser = Context.User as IGuildUser;
            string displayName;
            if (rollingUser.Nickname == null || rollingUser.Nickname == String.Empty)
            {
                displayName = rollingUser.Username;
            }
            else
            {
                displayName = rollingUser.Nickname;
            }

            builder.WithTitle(String.Format("{0} rolled {1}, {2} sided dice.", displayName, numOfDice, numSides))
                .WithDescription("**ROLLS:** " + string.Join(", ", rolls) + "\n\n**TOTAL OF ALL DICE:** " + total)
                .WithColor(Color.DarkPurple);

            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }
    }
}
