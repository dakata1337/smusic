namespace SMusic.Core;

using SMusic.Data.Models;

public class ArtistCore : BaseCore
{
    public ArtistCore(IServiceProvider s) : base(s) {}

    /// <summary>
    /// <para>Returns the artist matching the provided id</para>
    /// </summary>
    public Artist SearchArtist(int id)
        =>  _music.Artists
            .Where(x => x.ArtistId == id)
            .FirstOrDefault();

    /// <summary>
    /// <para>Returns all the artists that match the name</para>
    /// </summary>
    public IEnumerable<Artist> SearchArtists(string name)
        =>  _music.Artists.Where(x => x.Name.Contains(name));

    /// <summary>
    /// <para>Create an artist and add it to the staging database.</para>
    /// <para>NOTE: ArtistCore.SaveChanges must be called to update the database.</para>
    /// </summary>
    public Artist CreateArtist(string name)
    {
        Artist artist = new();
        artist.Name = name;
        _music.Artists.Add(artist);
        return artist;
    }

    /// <summary>
    /// <para>Remove the artist matching the id.</para>
    /// <para>NOTE: ArtistCore.SaveChanges must be called to update the database.</para>
    /// </summary>
    public void RemoveArtist(int id)
    {
        var artist = _music.Artists
            .Where(x => x.ArtistId == id)
            .FirstOrDefault();
        _music.Artists.Remove(artist);
    }

    /// <summary>
    /// <para>Update an artist</para>
    /// <para>NOTE: ArtistCore.SaveChanges must be called to update the database.</para>
    /// </summary>
    public void UpdateArtist(Artist artist)
    {
        _music.Artists.Update(artist);
    }
}
