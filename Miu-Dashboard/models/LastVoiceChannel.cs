using System;
using System.Collections.Generic;

#nullable disable

namespace Miu_Dashboard.models
{
    public partial class LastVoiceChannel
    {
        public long GuildId { get; set; }
        public long VoiceChannelId { get; set; }
    }
}
