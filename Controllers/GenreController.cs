using csharp_boolflix.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers;

public class GenreController : Controller
{
    // GET
    public IActionResult Index()
    {
        List<Genre> genres;

        using (BoolflixDbContext db = new BoolflixDbContext())
        {
            genres = db.Genres.ToList();
        }

        return View("Index", genres);
    }

    public IActionResult Show(int id)
    {
        using (BoolflixDbContext context = new BoolflixDbContext())
        {
            Genre genreFound = context.Genres.Where(genre => genre.Id == id).FirstOrDefault();
            
            if (genreFound == null)
            {
                return NotFound($"Il genere con id {id} non è stato trovato");
            }
            else
            {
                return View("Show", genreFound);
            }
        }
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        
        return View("Create");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Genre formData)
    {
        using (BoolflixDbContext context = new BoolflixDbContext())
        {
            Genre newGenre = new Genre();
            
            newGenre.Name = formData.Name;
           
            if (formData.ImgUrl != null)
            {
                newGenre.ImgUrl = formData.ImgUrl;
            }
            else
            {
                newGenre.ImgUrl="/img/placeholder.jpg";
            }
            
            
            context.Genres.Add(newGenre);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
 
    /*[HttpGet]
    public IActionResult Update(int id)
    {
        
    }

    [HttpPost]
    public IActionResult Update(int id)
    {
       
    }*/

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        using (BoolflixDbContext context = new BoolflixDbContext())
        {
            Genre genre = context.Genres.Where(genre => genre.Id == id).FirstOrDefault();
            if (genre == null)
            {
               return NotFound("Non trovato");
            }
            context.Genres.Remove(genre);
            context.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}