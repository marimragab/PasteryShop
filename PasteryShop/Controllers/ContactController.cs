using Microsoft.AspNetCore.Mvc;

namespace PasteryShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
