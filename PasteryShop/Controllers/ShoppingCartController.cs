﻿using Microsoft.AspNetCore.Mvc;
using PasteryShop.Services;
using PasteryShop.ViewModel;

namespace PasteryShop.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly IPieRepository _pieRepository;
		private readonly IShoppingCart _shoppingCart;

		public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart)
		{
			_pieRepository = pieRepository;
			_shoppingCart = shoppingCart;
		}

		public ViewResult Index()
		{
			var items = _shoppingCart.GetShoppingCartItems();

			var shoppingCartViewModel = new ShoppingCartViewModel
				(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

			return View(shoppingCartViewModel);
		}

		public RedirectToActionResult AddToShoppingCart(int pieId)
		{
			var selectedPie = _pieRepository.AllPies()
				.FirstOrDefault(p => p.PieId == pieId);

			if (selectedPie != null)
			{
				_shoppingCart.AddToCart(selectedPie);
			}
			return RedirectToAction("Index");
		}

		public RedirectToActionResult RemoveFromShoppingCart(int pieId)
		{
			var selectedPie = _pieRepository.AllPies()
				.FirstOrDefault(p => p.PieId == pieId);

			if (selectedPie != null)
			{
				_shoppingCart.RemoveFromCart(selectedPie);
			}
			return RedirectToAction("Index");
		}
	}
}
