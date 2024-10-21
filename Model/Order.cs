using Microsoft.VisualBasic;
using System.Text.Json.Serialization;

namespace RestaurantManagement.Model;

public class Order
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    [JsonIgnore]
    public Status? Status { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }
    public int ProductId { get; set; }
    [JsonIgnore]
    public Product? Product { get; set; }
    public int CustomerId { get; set; }
    [JsonIgnore]
    public Customer? Customer { get; set; }
    public int EmployeeId { get; set; }
    [JsonIgnore]
    public Employees? Employee { get; set; }
}
