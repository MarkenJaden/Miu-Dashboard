using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Miu_Dashboard.models
{
    public partial class miudiscordbotContext : DbContext
    {

        public miudiscordbotContext(DbContextOptions<miudiscordbotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GuildChannel> GuildChannels { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<LastVoiceChannel> LastVoiceChannels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=65.21.224.42;database=miu-discord-bot;user id=miu-discord-bot;password=", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.4-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<GuildChannel>(entity =>
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

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<LastVoiceChannel>(entity =>
            {
                entity.HasKey(e => e.GuildId)
                    .HasName("PRIMARY");

                entity.ToTable("LastVoiceChannel");

                entity.Property(e => e.GuildId)
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedNever()
                    .HasColumnName("GuildID");

                entity.Property(e => e.VoiceChannelId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("VoiceChannelID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
