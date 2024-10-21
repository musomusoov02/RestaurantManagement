using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Model;

namespace RestaurantManagement.Controllers;
[ApiController]
[Route("User")]
public class UserController : ControllerBase
{
    private readonly MyContext _context;
    public UserController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public int CreateUser(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
        return user.Id;
    }

    [HttpGet]
    public List<User> ListUser()
    {
        return _context.User.ToList();
    }

    [HttpGet("id")]
    public User GetUserById(int id)
    {
        var user = _context.User.Find(id);
        if (user == null)
        {
            return null;
        }
        return user;
    }

    [HttpPut("id")]
    public User UpdateUser(User user)
    {
        var UserUpdate = _context.User.Update(user);
        _context.SaveChanges();
        return user;
    }

    [HttpDelete("id")]
    public string DeleteUser(int id)
    {
        var user = _context.User.Find(id);
        if (user == null)
        {
            return null;
        }
        _context.User.Remove(user);
        _context.SaveChanges();
        return "Succesfuly";
    }
}
