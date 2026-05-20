using Microsoft.AspNetCore.Mvc;
using MvcSolidDemo.Services;

namespace MvcSolidDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }
    }
}