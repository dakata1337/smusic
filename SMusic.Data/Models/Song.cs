namespace SMusic.Data.Models;

public class Song
{
    public int SongId { get; private set; }
    public string Title { get; set; }
    public string Length { get; set; }
    public List<Artist> Artists { get; set; }
}