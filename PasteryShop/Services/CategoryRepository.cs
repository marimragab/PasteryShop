using PasteryShop.Models;

namespace PasteryShop.Services
{
	public class CategoryRepository : ICategoryRepository
	{
		//List<Category> categories = new List<Category>()
		//{
		//	new Category {CategoryId=1,Name="Fruit Pies",Description="All Fruity Pies"},
		//	new Category {CategoryId=2, Name = "Chocolate Pies",Description="Sweet Pies With Rich Chocolate." },
		//	new Category {CategoryId=3,Name="Cheese Cakes",Description="Cheesy All The Way"},
		//};

		PasteryShopContext context = new PasteryShopContext();

		public IEnumerable<Category> AllCategories()
		{
			return context.Categories.ToList();
		}
	}
}
