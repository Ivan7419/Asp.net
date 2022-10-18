using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyShop_MVC.DZ;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Не указан электронный адрес")]
    [EmailAddress(ErrorMessage = "Некорректный адрес")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Не указан логин")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Не указан пароль")]
    public string Password { get; set; }
}