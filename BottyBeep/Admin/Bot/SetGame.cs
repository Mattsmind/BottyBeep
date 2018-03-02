using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace BottyBeep.Admin.Bot
{
    public class SetGame : ModuleBase<SocketCommandContext>
    {
        [Command("setgame"), Alias("sg")]
        [RequireOwner]
        public async Task SetGameAsync(string mode = "playing", [Remainder]string msg = "a game")
        {
            var client = Context.Client as DiscordSocketClient;

            int gameMode = 0;
            switch (mode.ToLower())
            {
                case "playing":
                    gameMode = 1;
                    break;
                case "listening":
                    gameMode = 2;
                    break;
                case "watching":
                    gameMode = 3;
                    break;
                default:
                    break;
            }

            await client.SetGameAsync(msg, null, Discord.StreamType.NotStreaming + gameMode);
        }
    }
}
