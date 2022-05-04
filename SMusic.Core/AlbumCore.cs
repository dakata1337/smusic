namespace SMusic.Core;

using SMusic.Data.Models;

public class AlbumCore : BaseCore
{
    public AlbumCore(IServiceProvider s) : base(s) {}

    /// <summary>
    /// <para>Returns the album matching the provided id</para>
    /// </summary>
    public Album SearchAlbum(int id)
        => _music.Albums
            .Where(x => x.AlbumId == id)
            .FirstOrDefault();

    /// <summary>
    /// <para>Returns all the albums that match the genre</para>
    /// </summary>
    public IEnumerable<Album> SearchAlbums(Genre genre)
        => _music.Albums.Where(x => x.AlbumGenre == genre);

    /// <summary>
    /// <para>Returns all the albums that match the query</para>
    /// </summary>
    public IEnumerable<Album> SearchAlbums(string query)
        => _music.Albums
            .Where(x => x.Name.ToLower()
            .Contains(query.ToLower())).ToList();

    /// <summary>
    /// <para>Returns the first N albums sorted by monthly listeners</para>
    /// </summary>
    public IEnumerable<Album> SearchTopAlbums(int count)
        => _music.Albums
            .OrderByDescending(x => x.MonthlyListeners)
            .Take(count);

    /// <summary>
    /// <para>Create an album and add it to the staging database.</para>
    /// <para>NOTE: AlbumCore.SaveChanges must be called to update the database.</para>
    /// </summary>
    public Album CreateAlbum(string name, List<Artist> artists,
        List<Song> songs, Genre genre,
        string coverPath = "./images/random.jpg")
    {
        Album album = new();
        album.Name = name;
        album.Artists = artists;
        album.Songs = songs;
        album.AlbumGenre = genre;
        album.CoverPath = coverPath;
        _music.Albums.Add(album);
        return album;
    }

    /// <summary>
    /// <para>Remove the album matching the id.</para>
    /// <para>NOTE: AlbumCore.SaveChanges must be called to update the database.</para>
    /// </summary>
    public void RemoveAlbum(int id)
    {
        var album = _music.Albums
            .Where(x => x.AlbumId == id)
            .FirstOrDefault();
        _music.Albums.Remove(album);
    }

    /// <summary>
    /// <para>Update an album</para>
    /// <para>NOTE: AlbumCore.SaveChanges must be called to update the database.</para>
    /// </summary>
    public void UpdateAlbum(Album album)
    {
        _music.Albums.Update(album);
    }
}
