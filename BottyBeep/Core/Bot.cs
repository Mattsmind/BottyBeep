using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Core
{
    public class Bot
    {
        DiscordSocketClient _client;
        CommandHandler _handler;
        EventHandler _events;

        public async Task StartAsync()
        {
            string botToken = ConfigHandler.bot.botToken;
            if (botToken == "" || botToken == null) return;

            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            _events = new EventHandler(_client);

            await _client.LoginAsync(TokenType.Bot, botToken);
            await _client.StartAsync();

            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);

            await Task.Delay(-1);
        }
    }
}
