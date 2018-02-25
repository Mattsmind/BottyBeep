using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace BottyBeep
{
    class Program
    {
        DiscordSocketClient _client;
        Core.CommandHandler _handler;

        static void Main(string[] args) => 
            new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            string botToken = Core.ConfigHandler.bot.botToken;
            if (botToken == "" || botToken == null) return;

            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            _client.Log += Log;
            
            await _client.LoginAsync(TokenType.Bot, botToken);
            await _client.StartAsync();
                
            _handler = new Core.CommandHandler();
            await _handler.InitializeAsync(_client);

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            //Call Bot Logger here when implemented.
            Console.WriteLine(msg.Message);
            return Task.CompletedTask;
        }
    }
}
