using MyShop_MVC.DZ;

namespace MyShop_MVC.Models;

public class IndexViewModel
{
    public List<ViewProduct> Products { get; }
    public PageViewModel PageViewModel { get; }
    public IndexViewModel(List<ViewProduct> products, PageViewModel viewModel)
    {
        Products = products;
        PageViewModel = viewModel;
    }
}

