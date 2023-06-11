using PasteryShop.Models;

namespace PasteryShop.Services
{
	public interface IPieRepository
	{
		IEnumerable<Pie> AllPies();

		IEnumerable<Pie> PiesOfTheWeek();

		Pie? GetPieById(int id);

		IEnumerable<Pie> SearchPies(string searchQuery);
	}
}
