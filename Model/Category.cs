using System.Text.Json.Serialization;

namespace RestaurantManagement.Model;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public ICollection<Product>? products { get; set; }
}
