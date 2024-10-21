using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Model;

namespace RestaurantManagement;

public class MyContext : DbContext
{
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Employees> Employees { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<User> User { get; set; }

    public MyContext(DbContextOptions<MyContext> options) : base(options)
    { }
}
