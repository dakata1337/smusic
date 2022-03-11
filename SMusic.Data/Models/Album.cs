namespace SMusic.Data.Models;

public class Album
{
    public int AlbumId { get; private set; }
    public string Name { get; set; } = default!;
    public List<Song> Songs { get; set; } = default!;
    public List<Artist> Artists { get; set; } = default!;
}