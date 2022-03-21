namespace SMusic.Core;

using SMusic.Data.Models;

public class AlbumCore : BaseCore
{
    public AlbumCore(IServiceProvider s) : base(s) {}

    public IEnumerable<Album> SearchAlbums(int id)
        => _music.Albums.Where(x => x.AlbumId == id);

    public IEnumerable<Album> SearchAlbums(Genre genre)
        => _music.Albums.Where(x => x.AlbumGenre == genre);

    public IEnumerable<Album> SearchAlbums(string query)
        => _music.Albums.Where(x => x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase));

    public IEnumerable<Album> SearchTopAlbums(int count)
        => _music.Albums.OrderByDescending(x => x.MonthlyListeners).Take(count);
}
