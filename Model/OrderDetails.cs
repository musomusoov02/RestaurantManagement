using System.Text.Json.Serialization;

namespace RestaurantManagement.Model;

public class OrderDetails
{
    public string EmployeeName { get; set; }
    public int OrderCount { get; set; }
}
