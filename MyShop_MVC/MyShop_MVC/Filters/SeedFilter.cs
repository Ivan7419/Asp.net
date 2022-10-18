using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyShop_MVC.DZ;
using System.Text.RegularExpressions;

namespace MyShop_MVC.Filters;

public class GlobalSeedFilter: Attribute, IActionFilter
{
    ApplicationContext db;
    public GlobalSeedFilter(ApplicationContext context)
    {
        db = context;
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        db.SaveChanges();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        DB_Seed.Seed(db);
    }
}