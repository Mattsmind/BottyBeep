using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace BottyBeep.Core
{
    class EventHandler
    {
        DiscordSocketClient _client;
        //CommandHandler _handler;
        LogHandler _logger = new LogHandler();

        internal EventHandler(DiscordSocketClient client)
        {
            _client = client;
            _client.Log += _logger.LogAsync;
        }
    }
}
