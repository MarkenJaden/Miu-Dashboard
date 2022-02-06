using System;
using System.Collections.Generic;

namespace Miu_Dashboard_6._0.models
{
    public partial class History
    {
        public int Id { get; set; }
        public long DateTime { get; set; }
        public string Name { get; set; } = null!;
        public string Link { get; set; } = null!;
        public long GuildId { get; set; }
        public bool Queued { get; set; }
        public bool Played { get; set; }
    }
}
