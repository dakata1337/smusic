namespace SMusic.Data.Models;

public class Song
{
    public Song(string title, string length)
    {
        this.Title = title;
        this.Length = length;
    }
    public int SongId { get; set; }
    public string Title { get; set; }
    public string Length { get; set; }
    public List<Artist> Artists { get; set; }
}