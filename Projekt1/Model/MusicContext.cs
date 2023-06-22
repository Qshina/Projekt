using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public class MusicContext : DbContext
    {
        
        public DbSet<Albums> Albums { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Directory1 = Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName).FullName;
            string FilePath = Path.Combine(Directory1, "MusicShop.db");
            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.DataSource = FilePath;
            string connectionString = builder.ConnectionString;
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Albums>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Album");
                entityTypeBuilder.HasKey(h => h.id_album);
                entityTypeBuilder.Property(h => h.album_name);
                entityTypeBuilder.HasOne(h => h.Artists)
                      .WithMany()
                      .HasForeignKey(h => h.id_artist);

            });

            modelBuilder.Entity<Artists>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Artist");
                entityTypeBuilder.HasKey(r => r.id_artist);
                entityTypeBuilder.Property(r => r.artist_name);
                //entityTypeBuilder.HasOne(r => r.albums)
                //    .WithMany()
                //    .HasForeignKey(r => r.id_album);
                
            });
            modelBuilder.Entity<Genres>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Genre");
                entityTypeBuilder.HasKey(v => v.id_genre);
                entityTypeBuilder.Property(v => v.genre);
                entityTypeBuilder.HasOne(v => v.Tracks) // Zmiana na HasMany
                    .WithMany()
                    .HasForeignKey(t => t.id_track);
            });

            modelBuilder.Entity<Tracks>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Track");
                entityTypeBuilder.HasKey(h => h.id_track);
                entityTypeBuilder.Property(h => h.title);
                entityTypeBuilder.Property(h => h.creation_year);
                entityTypeBuilder.HasOne(h => h.Albums)
                    .WithMany()
                    .HasForeignKey(h => h.id_album);
                entityTypeBuilder.HasOne(h => h.Genres)
                    .WithMany()
                    .HasForeignKey(h => h.id_genre);
            });


        }

    }
}
