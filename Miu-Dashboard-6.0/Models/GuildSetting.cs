using System;
using System.Collections.Generic;

namespace Miu_Dashboard_6._0.models
{
    public partial class GuildSetting
    {
        public long GuildId { get; set; }
        public long ChannelId { get; set; }
        public long VoiceChannelId { get; set; }
        public string? SettingIdleImage { get; set; }
    }
}
