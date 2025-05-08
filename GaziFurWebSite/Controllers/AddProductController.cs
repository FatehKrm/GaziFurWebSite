using BusinessLayer.Abstruct;
using EntityLayer.Concrate;
using GaziFurWebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace GaziFurWebSite.Controllers
{
    public class AddProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IColorService _colorService;
        private readonly IProductImageService _productImageService;
        private readonly IWebHostEnvironment _env;

        public AddProductController(ICategoryService categoryService, IProductService productService,
            IColorService colorService, IProductImageService productImageService, IWebHostEnvironment env)
        {
            _categoryService = categoryService;
            _productService = productService;
            _colorService = colorService;
            _productImageService = productImageService;
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var model = new Color_CategoryViewModel
            {
                Categories = _categoryService.TGetAll(),
                Colors = _colorService.TGetAll()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Product product, List<IFormFile> productImageFiles, int categoryId,
   string productName, string productDescription, string price, string gender, string size,
   string isFeatured, int colorId)
        {
            // Price ve IsFeatured için kontrol ekleyelim (tip dönüşümleri)
            if (!decimal.TryParse(price, out decimal parsedPrice))
            {
                ModelState.AddModelError("Price", "Geçersiz fiyat formatı.");
                return View();
            }

            product.Size = size;
            product.Name = productName;
            product.Description = productDescription;
            product.Price = price;
            product.Gender = gender;
            product.CategoryId = categoryId;
            product.ColorId = colorId;
            product.IsFeatured = isFeatured;

            _productService.TAdd(product);

            if (productImageFiles != null && productImageFiles.Count > 0)
            {
                foreach (var file in productImageFiles)
                {
                    if (file != null && file.Length > 0)
                    {
                        // Dosya türünü kontrol et
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                        if (!allowedExtensions.Contains(extension))
                        {
                            ModelState.AddModelError("", "Sadece resim dosyaları yüklenebilir.");
                            return View();
                        }

                        // MIME türünü kontrol et
                        if (!file.ContentType.StartsWith("image/"))
                        {
                            ModelState.AddModelError("", "Geçersiz dosya türü.");
                            return View();
                        }

                        // Dosya boyutu sınırı (5 MB)
                        long maxSizeInBytes = 5 * 1024 * 1024; // 5 MB
                        if (file.Length > maxSizeInBytes)
                        {
                            ModelState.AddModelError("", "Maksimum dosya boyutu 5 MB olmalı.");
                            return View();
                        }

                        // Dosya adı çakışmalarını önlemek için GUID kullan
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var uploadPath = Path.Combine(_env.WebRootPath, "images", fileName);

                        // Dosya dizinini oluştur
                        if (!Directory.Exists(Path.GetDirectoryName(uploadPath)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(uploadPath)!);
                        }

                        // Dosyayı kaydet
                        using (var stream = new FileStream(uploadPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Görseli veritabanına ekle
                        ProductImage productImage = new ProductImage
                        {
                            ProductId = product.ProductId,
                            ImageUrl = "/images/" + fileName
                        };

                        _productImageService.TAdd(productImage);
                    }
                }
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult ListAllProducts()
        {
            var products = _productService.GetAllWithColor();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductDetail(int id)
        {
            var values = _productService.TGetAllProductDetails(id);
            return View(values);
        }
        public IActionResult DeleteProduct(int id)
        {
            _productService.TRemove(id);
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _productService.TGetAllProductDetails(id);
            return View(values);  
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.TUpdate(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
