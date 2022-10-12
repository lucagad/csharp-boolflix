using System.Diagnostics;
using csharp_boolflix.DBContext;
using Microsoft.AspNetCore.Mvc;
using csharp_boolflix.Models;

namespace csharp_boolflix.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Genre> genres;

        using (BoolflixDbContext db = new BoolflixDbContext())
        {
            genres = db.Genres.ToList();
        }

        return View("Index", genres);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}