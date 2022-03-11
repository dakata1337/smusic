namespace SMusic.Data.Models;

public class Artist
{
    public int ArtistId { get; private set; }
    public string Name { get; set; } = default!;
    public List<Album> Albums { get; set; } = default!;
    public override string ToString()
    {
        return this.Name;
    }
}