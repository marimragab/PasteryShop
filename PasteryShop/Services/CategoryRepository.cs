using PasteryShop.Models;

namespace PasteryShop.Services
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly PasteryShopContext _pasteryShopContext;

		public CategoryRepository(PasteryShopContext pasteryShopContext)
		{
			_pasteryShopContext = pasteryShopContext;
		}

		public IEnumerable<Category> AllCategories()
		{
			return _pasteryShopContext.Categories.OrderBy(c=>c.Name);
		}
	}
}
