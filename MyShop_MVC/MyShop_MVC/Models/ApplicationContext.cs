using Microsoft.EntityFrameworkCore;

namespace MyShop_MVC.DZ;

public class ApplicationContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
}