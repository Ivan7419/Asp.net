using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyShop_MVC.DZ;
using MyShop_MVC.Models;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyShop_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationContext Context;
        private ILogger logger;

        public HomeController(ApplicationContext db)
        {
            Context = db;
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = loggerFactory.CreateLogger("ShopLogger");
        }

        public IActionResult Index()
        {
            return View(Context.Categories.AsNoTracking().ToList());
        }

        [Route("Products/{category}")]
        [HttpGet]
        public IActionResult ShowByCategory(int category, int page=1)
        {
            int pageSize = 4;

            IEnumerable<ViewProduct> source = GetProducts(category);
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel(items, pageViewModel);
            return View(viewModel);
        }

        private IEnumerable<ViewProduct> GetProducts(int Category)
        {
            List<ViewProduct> products = Context.Products.AsNoTracking().
                Where(p => p.Category.Id == Category).
                Select(p => new ViewProduct(p.Id, p.Name, p.Price, p.Image, p.Description, p.Discount, p.CategoryId)).
                ToList();
            return products;
        }

        [Route("Profile")]
        [HttpGet]
        public IActionResult Profile()
        {
            if (Request.Cookies.ContainsKey("userId"))
            {
                ViewBag.User = Context.Users.FirstOrDefault(p => p.Id == Int32.Parse(Request.Cookies["userId"]));
                if (ViewBag.User.Login == "admin") return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Route("Profile")]
        [HttpPost]
        public IActionResult Profile([Bind("Login", "Password", "Email")] User user)
        {
            string message = "null";
            var us = Context.Users.FirstOrDefault(p => p.Login == user.Login);
            if (us != null && us.Password == user.Password)
            {
                if (us.Login == "admin") return RedirectToAction("Index", "Admin");
                ViewBag.User = us;
                Response.Cookies.Append("userId", ViewBag.User.Id.ToString());
                logger.LogInformation($"User {ViewBag.User.Id} logged in");
            }
            else if(us == null && ModelState.IsValid)
            {
                ViewBag.User = user;
                Context.Users.Add(user);
                Context.SaveChanges();
                Response.Cookies.Append("userId", ViewBag.User.Id.ToString());
                logger.LogInformation($"User {ViewBag.User.Id} registered");
            }
            else if ((us != null && us.Password != user.Password) || us == null)
            {
                ViewBag.Message = "Неверное имя пользователя или пароль";
            }
            return View();
        }

        public IActionResult ProfileExit()
        {
            Response.Cookies.Delete("userId");
            return RedirectToAction("Index");
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("MyBasket")]
        public IActionResult Basket()
        {
            if (Request.Cookies.ContainsKey("userId"))
            {
                List<Product> products = (from b in Context.Baskets
                    where b.UserId == Int32.Parse(Request.Cookies["userId"])
                    orderby b.Product.Name
                    select b.Product).ToList();
                List<ViewProduct> viewProducts = products.
                    Select(p => new ViewProduct(p.Id, p.Name, p.Price, p.Image, p.Description, p.Discount, p.CategoryId)).
                    ToList();
                return View(viewProducts);
            }
            else
            {
                return RedirectToAction("Profile");
            }
            
        }
        
        [Route("ProductDetails/{productId}")]
        [HttpGet]
        public IActionResult Details(int productId)
        {
            ViewBag.IsUser = Request.Cookies.ContainsKey("userId") ? true : false;
            Product product = Context.Products.AsNoTracking().Where(p => p.Id == productId).First();
            return View(product);
        }

        [Route("ProductDetails/{productId}")]
        [HttpPost]
        public IActionResult Details()
        {
            int id = Int32.Parse(Request.Form["idProduct"].ToString());
            int idUser = Int32.Parse(Request.Cookies["userId"].ToString());
            Product product = Context.Products.FirstOrDefault(pr => pr.Id == id);
            var user = Context.Users.FirstOrDefault(pr => pr.Id == idUser);
            Context.Baskets.Add(new Basket() { Product = product, User = user });
            Context.SaveChanges();
            ViewBag.IsUser = true;
            logger.LogInformation($"User {idUser} added product {product.Id} to the basket");
            return View(product);
        }

        public IActionResult SearchProduct(string name, int page = 1)
        {
            ViewBag.Name = name;
            int pageSize = 4;

            IEnumerable<ViewProduct> source = Context.Products.Where(p => p.Name.Contains(name) || p.Description.Contains(name)).
                Select(p => new ViewProduct(p.Id, p.Name, p.Price, p.Image, p.Description, p.Discount, p.CategoryId)).ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel(items, pageViewModel);
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}