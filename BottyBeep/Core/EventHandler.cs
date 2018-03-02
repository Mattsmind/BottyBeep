using Discord.WebSocket;

namespace BottyBeep.Core
{
    class EventHandler
    {
        DiscordSocketClient _client;
        LogHandler _logger = new LogHandler();

        internal EventHandler(DiscordSocketClient client)
        {
            _client = client;
            _client.Log += _logger.LogAsync;
        }
    }
}
