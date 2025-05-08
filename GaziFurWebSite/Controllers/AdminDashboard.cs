using BusinessLayer.Abstruct;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace GaziFurWebSite.Controllers
{
    public class AdminDashboard : Controller
    {
        private readonly IProductService _productService;

        public AdminDashboard(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var products = _productService.TGetAllModels();
            return View(products);
        }

    }
}
