using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESports.Models
{
    public partial class ESportsContext : DbContext
    {
        public ESportsContext()
        {
        }

        public ESportsContext(DbContextOptions<ESportsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tournament> Tournaments { get; set; } = null!;
        public virtual DbSet<TournamentPlayer> TournamentPlayers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ESports;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("Tournament");

                entity.Property(e => e.TournamentId).ValueGeneratedNever();

                entity.Property(e => e.TournamentDate).HasColumnType("date");

                entity.Property(e => e.TournamentGame)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TournamentName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TournamentPlayer>(entity =>
            {
                entity.HasKey(e => e.PlayerId)
                    .HasName("PK__Tourname__4A4E74C8F3FDAB51");

                entity.Property(e => e.PlayerId).ValueGeneratedNever();

                entity.Property(e => e.PlayerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.PlayerTournamentNavigation)
                    .WithMany(p => p.TournamentPlayers)
                    .HasForeignKey(d => d.PlayerTournament)
                    .HasConstraintName("FK_Tournament");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
