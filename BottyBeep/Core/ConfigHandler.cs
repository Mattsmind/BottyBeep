using Newtonsoft.Json;
using System.IO;

namespace BottyBeep.Core
{
    class ConfigHandler
    {
        private const string configFolder = "Resources";
        private const string configFile = "botconfig.json";
        private const string _config = configFolder + "/" + configFile;

        public static BotConfig bot;

        static ConfigHandler()
        {
            if (!Directory.Exists(configFolder))
            {
                Directory.CreateDirectory(configFolder);
            }

            if (!File.Exists(_config))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllTextAsync(_config, json);
            }
            else
            {
                string json = File.ReadAllText(_config);
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
            }
        }
    }

    public struct BotConfig
    {
        public string botToken;
        public char commandChar;
    }
}
