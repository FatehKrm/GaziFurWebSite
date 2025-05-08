using BusinessLayer.Abstruct;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace GaziFurWebSite.Controllers
{
    public class AboutUsController : Controller
    {
       private readonly IAboutService _aboutService;

        public AboutUsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _aboutService.TGetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateAboutUs()
        {
            var values = _aboutService.TGetAll().FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAboutUs(AboutUs aboutUs)
        {
            _aboutService.TUpdate(aboutUs);
            return RedirectToAction("Index", "AboutUs");
        }
    }
}
