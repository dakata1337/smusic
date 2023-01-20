namespace SMusic.Data;
using SMusic.Data.Models;
using Microsoft.EntityFrameworkCore;

public class MusicContext : DbContext
{
    private static Random _random = new();
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }

    public MusicContext()
    {
        if (Database.EnsureCreated())
        {
            Artist a1 = new Artist();
            a1.Name = "Bruh";
            Artists.Add(a1);

            Artist a2 = new Artist();
            a2.Name = "Lil Lol";
            Artists.Add(a2);

            Album p1 = new Album();
            p1.Artists = new List<Artist>() {
                a1, a2
            };
            p1.Name = "The big cringe";
            p1.AlbumGenre = Genre.HipHop;
            p1.MonthlyListeners = 69420;
            p1.Songs = new List<Song>() {
                new Song("N-words in Paris", TimeSpan.FromSeconds(230)),
                new Song("Le'cringe", TimeSpan.FromSeconds(193)),
            };
            Albums.Add(p1);

            this.SaveChanges();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=smusic.db;");
    }
}
