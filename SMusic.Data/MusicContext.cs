namespace SMusic.Data;
using SMusic.Data.Models;
using Microsoft.EntityFrameworkCore;

public class MusicContext : DbContext
{
    public DbSet<Album> Albums { get; set; } = default!;
    public DbSet<Artist> Artists { get; set; } = default!;

    private static bool _created = false;
    public MusicContext()
    {
        if (!_created) {
            _created = true;
            Database.EnsureDeleted();
            Database.EnsureCreated();

            var a1 = CreateArtist("Kanye West");
            var a2 = CreateArtist("Kanye East");

            Albums.Add(CreateAlbum("Crack", new Artist[] { a1, a2 }));
            this.SaveChanges();
        }
    }

    private Artist CreateArtist(string name)
    {
        Artist artist = new();
        artist.Name = name;
        Artists.Add(artist);
        return artist;
    }

    private Album CreateAlbum(string albumName, Artist[] artists)
    {
        Album album = new();
        album.Name = albumName;
        album.Artists = new List<Artist>(artists);
        return album;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=smusic.db;");
    }
}
