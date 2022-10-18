namespace MyShop_MVC.DZ;

public class Basket
{
    public int Id { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public int ProductCount { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
}