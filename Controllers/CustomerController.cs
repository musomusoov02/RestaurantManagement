using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Model;

namespace RestaurantManagement.Controllers;
[ApiController]
[Route("Customer")]
public class CustomerController : ControllerBase
{
    private readonly MyContext _context;
    public CustomerController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public int CreateCustomer(Customer customer)
    {
        _context.Customer.Add(customer);
        _context.SaveChanges();
        return customer.Id;
    }

    [HttpGet]
    public List<Customer> ListCustomer()
    {
        return _context.Customer.ToList();
    }

    [HttpGet("id")]
    public Customer GetCustomerById(int id)
    {
        var customer = _context.Customer.Find(id);
        if (customer == null)
        {
            return null;
        }
        return customer;
    }

    [HttpPut("id")]
    public Customer UpdateCustomer(Customer customer)
    {
        var CustomerUpdate = _context.Customer.Update(customer);
        _context.SaveChanges();
        return customer;
    }

    [HttpDelete("id")]
    public string DeleteCustomer(int id)
    {
        var customer = _context.Customer.Find(id);
        if (customer == null)
        {
            return null;
        }
        _context.Customer.Remove(customer);
        _context.SaveChanges();
        return "Succesfuly";
    }

}
