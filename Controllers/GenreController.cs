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

    /*[HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PizzasCategories formData)
    {
        if (!ModelState.IsValid)
        {
            PizzasCategories pizzasCategories = new PizzasCategories();
            pizzasCategories.Categories = new PizzaContext().Categories.ToList();
            pizzasCategories.Ingredients = new PizzaContext().Ingredients.ToList();
            return View("Create", pizzasCategories);
        }

        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizzaToCreate = new Pizza();
            
            pizzaToCreate.Name = formData.Pizza.Name;
            pizzaToCreate.Description = formData.Pizza.Description;
            
            if (formData.Pizza.ImgUrl != null)
            {
                pizzaToCreate.ImgUrl = formData.Pizza.ImgUrl;
            }
            else
            {
                pizzaToCreate.ImgUrl="/img/placeholder.jpg";
            }
            
            pizzaToCreate.Price = formData.Pizza.Price;
            pizzaToCreate.CategoryId = formData.Pizza.CategoryId;
            
            pizzaToCreate.Ingredients = context.Ingredients.Where(ingredient => formData.SelectedIngredients.Contains(ingredient.Id)).ToList<Ingredient>();
            context.Pizzas.Add(pizzaToCreate);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }*/
 
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