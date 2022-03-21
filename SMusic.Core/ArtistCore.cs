namespace SMusic.Core;

using SMusic.Data.Models;

public class ArtistCore : BaseCore
{
    public ArtistCore(IServiceProvider s) : base(s) {}

    public IEnumerable<Artist> SearchArtists(string name)
        =>  _music.Artists.Where(x => x.Name.Contains(name));

    public IEnumerable<Artist> SearchArtists(int id)
        =>  _music.Artists.Where(x => x.ArtistId == id);
}
