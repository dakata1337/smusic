using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SMusic.Core;
using SMusic.Data.Models;

namespace SMusic.Web.Controllers;

public class HomeController : Controller
{
    readonly AlbumCore  _albums;
    readonly ArtistCore _artists;
    public HomeController(IServiceProvider services)
    {
        _albums = services.GetRequiredService<AlbumCore>();
        _artists = services.GetRequiredService<ArtistCore>();
    }

    public IActionResult Index()
    {
        ViewBag.MostPlayed = _albums.SearchTopAlbums(5);
        return View();
    }

    public IActionResult Albums(int albumId)
    {
        ViewBag.Album = _albums.SearchAlbums(albumId).FirstOrDefault();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
