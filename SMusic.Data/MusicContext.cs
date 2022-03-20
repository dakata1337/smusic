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
            #if !DEBUG
            Database.EnsureCreated();
            #endif

            #if DEBUG
            Database.EnsureDeleted();
            Database.EnsureCreated();

            // TODO: maybe load albums from external source?
            var kanyeWest = CreateArtist("Kanye West");
            var kanyeEast = CreateArtist("Kanye East");

            CreateAlbum("Graduation", Genre.HipHop, new List<Artist> { kanyeWest, kanyeEast }, new List<Song> {
                new("Good Morning", "3:15"),
                new("Champion", "2:47"),
                new("Stronger", "5:11"),
                new("I Wonder", "4:03"),
                new("Good Life", "3:27"),
                new("Can't Tell Me Nothing", "4:31"),
                new("Barry Bonds", "3:24"),
                new("Drunk and Hot Girls", "5:13"),
                new("Flashing Lights", "3:57"),
                new("Everythin I Am", "3:47"),
                new("The Glory", "3:32"),
                new("Homecoming", "3:23"),
                new("Big Brother", "4:47"),
                new("Good Night", "3:05"),
            }, _random.Next(4_000_000, 20_000_000), "images/kanye-graduation.jpg");

            CreateAlbum("The Life Of Pablo", Genre.HipHop, new List<Artist> { kanyeWest }, new List<Song> {
                new("Ultralight Beam", "5:20"),
                new("Father Stretch My Hands Pt.1", "2:15"),
                new("Father Stretch My Hands Pt.2", "2:10"),
                new("Famous", "3:16"),
                new("Feedback", "2:27"),
                new("Low Lights", "2:21"),
                new("Highlights", "3:19"),
                new("Freestyle 4", "2:03"),
                new("I Love Kanye", "0:44"),
                new("Waves", "3:01"),
                new("FML", "3:56"),
                new("Real Friends", "4:11"),
                new("Wolves", "5:01"),
                new("Frank's Track", "0:38"),
                new("30 Hours", "5:23"),
                new("No More Parties In LA", "6:14"),
                new("Facts (Charlie Heat Version)", "3:20"),
                new("Fade", "3:13"),
                new("Saint Pablo", "6:12"),
            }, _random.Next(4_000_000, 20_000_000), "images/kanye-the-life-of-pablo.jpg");

            this.SaveChanges();
            #endif
        }
    }

    private Artist CreateArtist(string name)
    {
        Artist artist = new();
        artist.Name = name;
        Artists.Add(artist);
        return artist;
    }

    private Album CreateAlbum(string albumName, Genre genre, List<Artist> artists, List<Song> songs, int monthlyListeners, string coverPath)
    {
        Album album = new();
        album.Name = albumName;
        album.AlbumGenre = genre;
        album.Artists = artists;
        album.Songs = songs;
        album.MonthlyListeners = monthlyListeners;
        album.CoverPath = coverPath;
        Albums.Add(album);
        return album;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=smusic.db;");
    }
}
