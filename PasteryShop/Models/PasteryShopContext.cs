using Microsoft.EntityFrameworkCore;

namespace PasteryShop.Models
{
	public class PasteryShopContext:DbContext 
	{
		public PasteryShopContext(DbContextOptions<PasteryShopContext> options):base(options)
		{

		}
		public DbSet<Pie> Pies { get; set; }

		public DbSet<Category> Categories { get; set; }
        
		public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

		public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
