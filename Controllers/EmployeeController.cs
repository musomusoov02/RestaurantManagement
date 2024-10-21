using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Model;
using System.Reflection.Metadata.Ecma335;

namespace RestaurantManagement.Controllers;
[ApiController]
[Route("Employee")]
public class EmployeeController : ControllerBase
{
    private readonly MyContext _context;

    public EmployeeController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public int CreateEmployee(Employees employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return employee.Id;
    }

    [HttpGet]
    public List<Employees> ListEmployee()
    {
        return _context.Employees.ToList();
    }

    [HttpGet("id")]
    public Employees GetEmployeeById(int id)
    {
        var employees = _context.Employees.Find(id);
        if (employees == null)
        {
            return null;
        }
        return employees;
    }

    [HttpPut("id")]
    public Employees UpdateEmployee(Employees employee)
    {
        var update = _context.Employees.Update(employee);
        _context.SaveChanges();
        return employee;
    }

    [HttpDelete("id")]
    public string DeleteEmployee(int id)
    {
        var result = _context.Employees.Find(id);
        if (result == null)
        {
            return null;
        }
        _context.Employees.Remove(result);
        _context.SaveChanges();
        return "Succesfuly";
    }
}
