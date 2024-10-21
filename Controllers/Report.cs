using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Model;

namespace RestaurantManagement.Controllers;
[ApiController]
[Route("Report")]
public class Report : ControllerBase
{
    public readonly MyContext _context;
    public Report(MyContext context)
    {
        _context = context;
    }


    [HttpGet("Employees who sold the most products")]
    public ActionResult<List<OrderDetails>> GetReport()
    {
        var employeeOrderCounts = _context.Order
        .GroupBy(o => o.EmployeeId)
        .Select(g => new
        {
            EmployeeId = g.Key,
            OrderCount = g.Count()
        })
        .OrderByDescending(x => x.OrderCount)
        .ToList();

        var re = _context.Employees.Find(employeeOrderCounts[0].EmployeeId);
        OrderDetails orderDetails = new OrderDetails()
        {
            EmployeeName = re.Name,
            OrderCount = employeeOrderCounts[0].OrderCount
        };
        return Ok(orderDetails);
    }

    [HttpGet("Customer who made the most purchases")]
    public ActionResult<List<CustomerReport>> GetReport2()
    {
        var byCounts = _context.Order
        .GroupBy(o => o.CustomerId)
        .Select(g => new
        {
            CustomerId = g.Key,
            OrderCount = g.Count()
        })
        .OrderByDescending(x => x.OrderCount)
        .ToList();

        var re = _context.Customer.Find(byCounts[0].CustomerId);
        CustomerReport report = new CustomerReport()
        {
            CustomerName = re.Name,
            BuyCount = byCounts[0].OrderCount
        };
        return Ok(report);
    }

    [HttpGet("the most category of products")]
    public ActionResult<List<CategoryProductReport>> GetReport3()
    {
        var res = _context.Product
        .GroupBy(o => o.CategoryId)
        .Select(g => new
        {
            CategoryId = g.Key,
            ProductCount = g.Count()
        })
        .OrderByDescending(x => x.ProductCount)
        .ToList();

        var re = _context.Category.Find(res[0].CategoryId);
        CategoryProductReport report = new CategoryProductReport()
        {
            CategoryName = re.Name,
            productCount = res[0].ProductCount
        };
        return Ok(report);
    }
}
