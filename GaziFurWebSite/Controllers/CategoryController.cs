using BusinessLayer.Abstruct;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace GaziFurWebSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]  //AddCategory
        public IActionResult Index()
        {
            var values = _categoryService.TGetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Category category, string Name, string Description, IFormFile Photo)
        {
            if (Photo != null && Photo.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Photo.FileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    await Photo.CopyToAsync(stream);
                }

                category.Name = Name;
                category.Description = Description;
                category.CategoryPhoto = "/images/" + fileName;

                _categoryService.TAdd(category);

                return RedirectToAction("Dashboard","AdminDashboard");
            }
             
            return View();
        }
    }
}
