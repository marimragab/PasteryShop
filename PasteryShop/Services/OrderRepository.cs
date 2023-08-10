using PasteryShop.Models;

namespace PasteryShop.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PasteryShopContext _pasteryShopContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(PasteryShopContext pasteryShopContext, IShoppingCart shoppingCart)
        {
            _pasteryShopContext = pasteryShopContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems=_shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            _pasteryShopContext.Orders.Add(order);

            _pasteryShopContext.SaveChanges();
        }
    }
}
