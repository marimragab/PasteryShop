using Microsoft.AspNetCore.Mvc;
using PasteryShop.Models;
using PasteryShop.Services;
using PasteryShop.ViewModel;
using System.Diagnostics;

namespace PasteryShop.Controllers
{
    public class HomeController : Controller
    {
		private readonly IPieRepository _pieRepository;

		public HomeController(IPieRepository pieRepository)
		{
			_pieRepository = pieRepository;
		}
	
        public IActionResult Index()
        {
            var piesOfTheWeek=_pieRepository.PiesOfTheWeek();
            var homeViewModel=new HomeViewModel(piesOfTheWeek);
            return View(homeViewModel); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
