using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyShop_MVC.DZ;
using MyShop_MVC.Models;

namespace MyShop_MVC.Controllers
{
    public class AdminController : Controller
    {
        public ApplicationContext Context;
        private ILogger logger;

        public AdminController(ApplicationContext db)
        {
            Context = db;
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = loggerFactory.CreateLogger("ShopLogger");
        }

        [Route("DbEdit")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(Context.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            Context.Products.Update(product);
            await Context.SaveChangesAsync();
            logger.LogInformation($"Product {product.Id} added");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            Context.Categories.Update(category);
            await Context.SaveChangesAsync();
            logger.LogInformation($"Category {category.Id} added");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ShowProducts()
        {
            ViewBag.Categories = Context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult ShowProducts(int categoryId, int page = 1)
        {
            ViewBag.Categories = Context.Categories.ToList();
            ViewBag.SelectedCategory = categoryId;

            int pageSize = 4;

            IEnumerable<ViewProduct> source = GetProducts(categoryId);
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel(items, pageViewModel);
            return View(viewModel);
        }

        public IActionResult ShowCategories()
        {
            return View(GetCategories());
        }

        public IActionResult EditProduct(int productId)
        {
            ViewBag.Categories = new SelectList(Context.Categories.ToList(), "Id", "Name");
            Product product = Context.Products.Where(p => p.Id == productId).First();
            return View(product);
        }

        public async Task<IActionResult> SaveProduct(Product product)
        {
            Context.Products.Update(product);
            await Context.SaveChangesAsync();
            logger.LogInformation($"Product {product.Id} updated");
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(int categoryId)
        {
            Category category = Context.Categories.Where(c => c.Id == categoryId).First();
            return View(category);
        }

        public IActionResult DeleteCategory(int categoryId)
        {
            Context.Remove(Context.Categories.Where(c => c.Id == categoryId).FirstOrDefault());
            Context.SaveChanges();
            logger.LogInformation($"Category {categoryId} deleted");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SaveCategory(Category category)
        {
            Context.Categories.Update(category);
            await Context.SaveChangesAsync();
            logger.LogInformation($"Category {category.Id} updated");
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int productId)
        {
            Context.Remove(Context.Products.Where(p => p.Id == productId).FirstOrDefault());
            Context.SaveChanges();
            logger.LogInformation($"Product {productId} deleted");
            return RedirectToAction("Index");
        }

        public List<ViewCategory> GetCategories()
        {
            List<ViewCategory> categories = Context.Categories.AsNoTracking().
                Select(c => new ViewCategory(c.Id, c.Name)).
                ToList();
            return categories;
        }

        public List<ViewProduct> GetProducts(int categoryId)
        {
            List<ViewProduct> products = Context.Products.AsNoTracking().
                Where(p => p.CategoryId == categoryId).
                Select(p => new ViewProduct(p.Id, p.Name, p.Price, p.Image, p.Description, p.Discount, p.CategoryId)).
                ToList();
            return products;
        }
    }
}
