using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SMusic.Data;
using SMusic.Data.Models;

namespace SMusic.Web.Controllers;

public class HomeController : Controller
{
    readonly MusicContext _music;
    public HomeController(IServiceProvider services)
    {
        _music = services.GetRequiredService<MusicContext>();
    }

    public IActionResult Index()
    {
        ViewBag.MostPlayed = _music.Albums.OrderByDescending(x => x.MonthlyListeners).Take(5);
        return View();
    }

    public IActionResult Albums(int albumId)
    {
        ViewBag.Album = _music.Albums.Where(x => x.AlbumId == albumId).FirstOrDefault();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
