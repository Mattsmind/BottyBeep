using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace BottyBeep.Core
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();

            await _service.AddModulesAsync(Assembly.GetEntryAssembly());

            _client.MessageReceived += HandleCommandsAsync;
        }

        private async Task HandleCommandsAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;

            if (msg == null)
                return;

            var context = new SocketCommandContext(_client, msg);
            int argPos = 0;

            if (msg.HasCharPrefix(ConfigHandler.bot.commandChar, ref argPos) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    //Call the BotLogger system here once implemented.
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
