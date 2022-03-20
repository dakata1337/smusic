namespace SMusic.Data.Models;

public enum Genre
{
    Pop,
    HipHop,
    Techno,
    Electronic,
    Rock,
    Metal
}

public class Album
{
    public int AlbumId { get; private set; }
    public string Name { get; set; }
    public List<Song> Songs { get; set; }
    public List<Artist> Artists { get; set; }
    public Genre AlbumGenre { get; set; }
    public int MonthlyListeners { get; set; }
    public string CoverPath { get; set; }

    public string GenreToString()
    {
        switch (this.AlbumGenre) {
            case Genre.HipHop:
                return "Hip-Hop";
            default:
                return Enum.GetName(this.AlbumGenre);
        }
    }

    public string MonthlyListenersToString()
    {
        if (this.MonthlyListeners < 1000)
            return this.MonthlyListeners.ToString();

        int exp = (int)(Math.Log(this.MonthlyListeners) / Math.Log(1000));
        int prefix = (int)(this.MonthlyListeners / Math.Pow(1000, exp));
        return $"{prefix}{"kMGTPE"[exp-1]}";
    }
}