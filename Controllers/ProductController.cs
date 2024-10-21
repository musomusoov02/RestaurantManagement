using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Model;

namespace RestaurantManagement.Controllers;
[ApiController]
[Route("Product")]
public class ProductController : ControllerBase
{
    private readonly MyContext _context;
    public ProductController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public int CreateProduct(Product product)
    {
        _context.Product.Add(product);
        _context.SaveChanges();
        return product.Id;
    }

    [HttpGet]
    public List<Product> ListProducts()
    {
        return _context.Product.ToList();
    }

    [HttpGet("id")]
    public Product GetProductById(int id)
    {
        var product = _context.Product.Find(id);
        if (product == null)
        {
            return null;
        }
        return product;
    }

    [HttpPut("id")]
    public Product UpdateProduct(Product product)
    {
        var UpdateProducts = _context.Product.Update(product);
        _context.SaveChanges();
        return product;
    }

    [HttpDelete("id")]
    public string DeleteProduct(int id)
    {
        var result = _context.Product.Find(id);
        if(result==null)
        {
            return null;
        }
        _context.Product.Remove(result);
        _context.SaveChanges();
        return "Succesfuly";
    }
}
