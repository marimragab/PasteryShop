using Microsoft.AspNetCore.Mvc;

namespace PasteryShop.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
