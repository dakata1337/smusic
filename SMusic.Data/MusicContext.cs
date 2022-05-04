namespace SMusic.Data;
using SMusic.Data.Models;
using Microsoft.EntityFrameworkCore;

public class MusicContext : DbContext
{
    private static Random _random = new();
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }

    private static bool _created = false;
    public MusicContext()
    {
        if (!_created) {
            _created = true;
            Database.EnsureCreated();
            this.SaveChanges();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=smusic.db;");
    }
}
