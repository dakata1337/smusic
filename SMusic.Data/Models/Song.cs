namespace SMusic.Data.Models;

public class Song
{
    public int SongId { get; private set; }
    public string Title { get; set; } = default!;
    public string Length { get; set; } = default!;
    public List<Artist> Artists { get; set; } = default!;
}