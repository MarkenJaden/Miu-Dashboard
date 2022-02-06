using System;
using System.Collections.Generic;

#nullable disable

namespace Miu_Dashboard.models
{
    public partial class History
    {
        public int Id { get; set; }
        public long DateTime { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public long GuildId { get; set; }
        public bool Queued { get; set; }
        public bool Played { get; set; }
    }
}
