using PasteryShop.Models;

namespace PasteryShop.Services
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> AllCategories();
	}
}
