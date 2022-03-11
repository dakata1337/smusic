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

            CreateAlbum("Meth", new List<Artist> { a1, a2 }, new List<Song> {
                new() {
                    Title = "Cooking Meth",
                    Length = "3.41"
                },
                new() {
                    Title = "Smoking Meth",
                    Length = "3.11"
                },
                new() {
                    Title = "Being Interrogated By The Police",
                    Length = "9.10"
                },
            });

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

    private Album CreateAlbum(string albumName, List<Artist> artists, List<Song> songs)
    {
        Album album = new();
        album.Name = albumName;
        album.Artists = artists;
        album.Songs = songs;
        Albums.Add(album);
        return album;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=smusic.db;");
    }
}
