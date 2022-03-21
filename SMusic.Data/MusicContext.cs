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
                new("Good Morning",                 TimeSpan.Parse("0:03:15")),
                new("Champion",                     TimeSpan.Parse("0:02:47")),
                new("Stronger",                     TimeSpan.Parse("0:05:11")),
                new("I Wonder",                     TimeSpan.Parse("0:04:03")),
                new("Good Life",                    TimeSpan.Parse("0:03:27")),
                new("Can't Tell Me Nothing",        TimeSpan.Parse("0:04:31")),
                new("Barry Bonds",                  TimeSpan.Parse("0:03:24")),
                new("Drunk and Hot Girls",          TimeSpan.Parse("0:05:13")),
                new("Flashing Lights",              TimeSpan.Parse("0:03:57")),
                new("Everythin I Am",               TimeSpan.Parse("0:03:47")),
                new("The Glory",                    TimeSpan.Parse("0:03:32")),
                new("Homecoming",                   TimeSpan.Parse("0:03:23")),
                new("Big Brother",                  TimeSpan.Parse("0:04:47")),
                new("Good Night",                   TimeSpan.Parse("0:03:05")),
            }, _random.Next(4_000_000, 20_000_000), "images/kanye-graduation.jpg");

            CreateAlbum("The Life Of Pablo", Genre.HipHop, new List<Artist> { kanyeWest }, new List<Song> {
                new("Ultralight Beam",              TimeSpan.Parse("0:05:20")),
                new("Father Stretch My Hands Pt.1", TimeSpan.Parse("0:02:15")),
                new("Father Stretch My Hands Pt.2", TimeSpan.Parse("0:02:10")),
                new("Famous",                       TimeSpan.Parse("0:03:16")),
                new("Feedback",                     TimeSpan.Parse("0:02:27")),
                new("Low Lights",                   TimeSpan.Parse("0:02:21")),
                new("Highlights",                   TimeSpan.Parse("0:03:19")),
                new("Freestyle 4",                  TimeSpan.Parse("0:02:03")),
                new("I Love Kanye",                 TimeSpan.Parse("0:00:44")),
                new("Waves",                        TimeSpan.Parse("0:03:01")),
                new("FML",                          TimeSpan.Parse("0:03:56")),
                new("Real Friends",                 TimeSpan.Parse("0:04:11")),
                new("Wolves",                       TimeSpan.Parse("0:05:01")),
                new("Frank's Track",                TimeSpan.Parse("0:00:38")),
                new("30 Hours",                     TimeSpan.Parse("0:05:23")),
                new("No More Parties In LA",        TimeSpan.Parse("0:06:14")),
                new("Facts (Charlie Heat Version)", TimeSpan.Parse("0:03:20")),
                new("Fade",                         TimeSpan.Parse("0:03:13")),
                new("Saint Pablo",                  TimeSpan.Parse("0:06:12")),
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
