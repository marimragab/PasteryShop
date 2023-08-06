using Microsoft.EntityFrameworkCore;
using PasteryShop.Models;

namespace PasteryShop.Services
{
	public class ShoppingCart : IShoppingCart
	{
		private readonly PasteryShopContext _pasteryShopContext;

        public ShoppingCart(PasteryShopContext pasteryShopContext)
        {
			_pasteryShopContext = pasteryShopContext;	
        }

		public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

		public string? ShoppingCartId { get; set; }

		public static ShoppingCart GetCart(IServiceProvider services)
		{
			ISession? session = services.GetRequiredService<IHttpContextAccessor>()?
				.HttpContext?.Session;

			PasteryShopContext context=services.GetService<PasteryShopContext>()
				??throw new Exception("Error Initializing");

			string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

			session?.SetString("CartId", cartId);

			return new ShoppingCart(context) { ShoppingCartId = cartId };
		}

        public void AddToCart(Pie pie)
		{
			var shoppingCartItem = _pasteryShopContext.ShoppingCartItems.
				SingleOrDefault(s => s.Pie.PieId == pie.PieId &&
				s.ShoppingCardId == ShoppingCartId);

			if (shoppingCartItem == null)
			{
				shoppingCartItem = new ShoppingCartItem
				{
					ShoppingCardId = ShoppingCartId,
					Pie = pie,
					Amount = 1

				};
				_pasteryShopContext.ShoppingCartItems.Add(shoppingCartItem);
			}
			else
			{
				shoppingCartItem.Amount++;
			}

			_pasteryShopContext.SaveChanges();
		}

		public int RemoveFromCart(Pie pie)
		{
			var shoppingCartItem = _pasteryShopContext.ShoppingCartItems.
				SingleOrDefault(s => s.Pie.PieId == pie.PieId &&
				s.ShoppingCardId == ShoppingCartId);

			var localAmount = 0;

			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Amount > 1)
				{
					shoppingCartItem.Amount--;
					localAmount = shoppingCartItem.Amount;
				}
				else
				{
					_pasteryShopContext.ShoppingCartItems.Remove(shoppingCartItem);
				}
			}
			_pasteryShopContext.SaveChanges();

			return localAmount;
		}

		public void ClearCart()
		{
			var cartItems = _pasteryShopContext.ShoppingCartItems
				.Where(c => c.ShoppingCardId == ShoppingCartId);

			_pasteryShopContext.ShoppingCartItems.RemoveRange(cartItems);

			_pasteryShopContext.SaveChanges();
		}

		public List<ShoppingCartItem> GetShoppingCartItems()
		{
			return ShoppingCartItems ??= _pasteryShopContext.ShoppingCartItems
				.Where(c => c.ShoppingCardId == ShoppingCartId)
				.Include(c => c.Pie)
				.ToList();
		}

		public decimal GetShoppingCartTotal()
		{
			var total = _pasteryShopContext.ShoppingCartItems
			   .Where(c => c.ShoppingCardId == ShoppingCartId)
			   .Select(c=>c.Pie.Price * c.Amount).Sum();
			return total;
		}

	}
}
