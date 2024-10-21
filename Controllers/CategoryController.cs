using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Model;

namespace RestaurantManagement.Controllers;
[ApiController]
[Route("Category")]
public class CategoryController : ControllerBase
{
    private readonly MyContext _context;
    public CategoryController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public int CreateCategory(Category category)
    {
        _context.Category.Add(category);
        _context.SaveChanges();
        return category.Id;
    }

    [HttpGet]
    public List<Category> ListCategories()
    {
        return _context.Category.ToList();
    }

    [HttpGet("id")]
    public Category GetCategoriesById(int id)
    {
        var category = _context.Category.Find(id);
        if (category == null)
        {
            return null;
        }
        return category;
    }

    [HttpPut("id")]
    public Category UpdateCategory(Category category)
    {
        var CategoryUpdate = _context.Category.Update(category);
        _context.SaveChanges();
        return category;
    }

    [HttpDelete("id")]
    public string DeleteCategory(int id)
    {
        var category= _context.Category.Find(id);
        if (category == null)
        {
            return null;
        }
        _context.Category.Remove(category);
        _context.SaveChanges();
        return "Succesfuly";
    }
}
