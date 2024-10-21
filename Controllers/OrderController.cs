using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Model;

namespace RestaurantManagement.Controllers;
[ApiController]
[Route("Order")]
public class OrderController : ControllerBase
{
    private readonly MyContext _context;
    public OrderController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public int CreateOrder(Order order)
    {
        _context.Order.Add(order);
        _context.SaveChanges();
        return order.Id;
    }

    [HttpGet]
    public List<Order> ListOrder()
    {
        return _context.Order.ToList();
    }

    [HttpGet("id")]
    public Order GetOrderById(int id)
    {
        var Order = _context.Order.Find(id);
        if (Order == null)
        {
            return null;
        }
        return Order;
    }

    [HttpPut("id")]
    public Order UpdateOrder(Order order)
    {
        var update = _context .Order.Update(order); 
        _context.SaveChanges();
        return order;
    }

    [HttpDelete("id")]
    public string DeleteOrder(int id)
    {
        var order = _context.Order.Find(id);
        if (order == null)
        {
            return null;
        }
        _context.Order.Remove(order);
        _context.SaveChanges();
        return "Succesfuly";
    }
}
