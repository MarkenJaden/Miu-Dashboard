using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Miu_Dashboard_6._0.models
{
    public partial class miudiscordbotContext : DbContext
    {
        public miudiscordbotContext()
        {
        }

        public miudiscordbotContext(DbContextOptions<miudiscordbotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GuildSetting> GuildSettings { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql($"server=65.21.224.42;database=miu-discord-bot;user id=miu-discord-bot;password={File.ReadAllText("sensitive-data")}", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<GuildSetting>(entity =>
            {
                entity.HasKey(e => e.GuildId)
                    .HasName("PRIMARY");

                entity.Property(e => e.GuildId)
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedNever()
                    .HasColumnName("GuildID");

                entity.Property(e => e.ChannelId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ChannelID");

                entity.Property(e => e.SettingIdleImage)
                    .HasColumnType("text")
                    .HasColumnName("Setting_IdleImage");

                entity.Property(e => e.VoiceChannelId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("VoiceChannelID")
                    .HasDefaultValueSql("-1");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");

                entity.HasIndex(e => e.GuildId, "GuildID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DateTime).HasColumnType("bigint(20)");

                entity.Property(e => e.GuildId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("GuildID");

                entity.Property(e => e.Link).HasColumnType("text");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
