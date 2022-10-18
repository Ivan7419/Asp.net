using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MyShop_MVC.DZ;

public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Не указано название")]
    public string Name { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}