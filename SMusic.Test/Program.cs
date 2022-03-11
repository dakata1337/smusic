namespace SMusic.Test;
using SMusic.Data;

class Program
{
    public static void Main(string[] args)
    {
        MusicContext context = new MusicContext();
        using (context)
        {
            foreach (var item in context.Artists) {
                Console.WriteLine($"{item.Name}");
                foreach (var album in item.Albums) {
                    Console.WriteLine($" - {album.Name}");
                }
            }
        }
    }
}