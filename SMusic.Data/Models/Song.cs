namespace SMusic.Data.Models;

public class Song
{
    public Song(string title, TimeSpan length)
    {
        this.Title = title;
        this.Length = length;
    }
    public int SongId { get; set; }
    public string Title { get; set; }
    public TimeSpan Length { get; set; }
    public List<Artist> Artists { get; set; }

    public string GetLength()
        => Length.ToString(@"hh\:mm\:ss")
                .TrimStart(' ', '0', ':');
}