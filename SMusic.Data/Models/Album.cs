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

    public string GenreToString()
    {
        switch (this.AlbumGenre) {
            case Genre.HipHop:
                return "Hip-Hop";
            default:
                return Enum.GetName(this.AlbumGenre);
        }
    }
}