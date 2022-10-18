namespace MyShop_MVC.Models;

public record class ViewProduct(int Id, string? Name, double Price, string? Image, string? Description, int Discount, int CategoryId);