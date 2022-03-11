namespace SMusic.Test;
using SMusic.Data;

class Program
{
    public static void Main(string[] args)
    {
        MusicContext context = new MusicContext();
        using (context)
        {
            foreach (var album in context.Albums)
            {
                Console.WriteLine($"Artists: {string.Join(", ", album.Artists)}");
                Console.WriteLine($"Songs:");
                foreach (var song in album.Songs)
                {
                    Console.WriteLine($" - {song.Title} | Length {song.Length}");
                }
            }
        }
    }
}