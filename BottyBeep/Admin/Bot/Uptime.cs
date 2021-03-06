﻿using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace BottyBeep.Admin.Bot
{
    public class Uptime : ModuleBase<SocketCommandContext>
    {
        [RequireBotPermission(ChannelPermission.SendMessages)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [Command("uptime")]
        public async Task GetUptimeAsync()
        {

            EmbedBuilder builder = new EmbedBuilder();

            DateTime procStartTime = Process.GetCurrentProcess().StartTime;
            DateTime timeNow = DateTime.Now;

            TimeSpan uptime = timeNow.Subtract(procStartTime);
            CultureInfo culture = new CultureInfo("en-US");
            string format = @"ddd\:hh\:mm\:ss";

            string[] splitTime = uptime.ToString(format, culture).Split(":", StringSplitOptions.RemoveEmptyEntries);

            builder.WithTitle("Uptime")
                .WithDescription($"{splitTime[0]} Days, {splitTime[1]} Hours, {splitTime[2]} Minutes and {splitTime[3]} Seconds.")
                .WithColor(Color.LighterGrey);

            await ReplyAsync("", false, builder.Build());
        }
    }
}
