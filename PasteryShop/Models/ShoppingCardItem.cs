﻿namespace PasteryShop.Models
{
	public class ShoppingCartItem
	{
		public int ShoppingCartItemId { get; set; }

		public Pie Pie { get; set; } = default!;

		public int Amount { get; set; }

		public string? ShoppingCardId { get; set; }
	}
}
