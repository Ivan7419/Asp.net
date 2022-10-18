using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MyShop_MVC.DZ;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Не указано название")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Не указана цена")]
    [Range(1, 999999, ErrorMessage = "Недопустимая цена")]
    public double Price { get; set; }
    [Required(ErrorMessage = "Не указана скидка")]
    [Range(0, 100, ErrorMessage = "Недопустимая скидка")]
    public int Discount { get; set; } = 0;
    [Url(ErrorMessage = "Некорректный URL")]
    public string? Image { get; set; }
    public string? Description { get; set; }

    [Required(ErrorMessage = "Не указана категория")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}