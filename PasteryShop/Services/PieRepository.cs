using Microsoft.EntityFrameworkCore;
using PasteryShop.Models;

namespace PasteryShop.Services
{
	public class PieRepository : IPieRepository
	{
		private readonly PasteryShopContext _pasteryShopContext;

		public PieRepository(PasteryShopContext pasteryShopContext)
		{
			_pasteryShopContext = pasteryShopContext;
		}

		public IEnumerable<Pie> AllPies()
		{
			return _pasteryShopContext.Pies.Include(p=>p.Category);	
		}

		public IEnumerable<Pie> PiesOfTheWeek()
		{
			return _pasteryShopContext.Pies.Where(p => p.IsPieOfTheWeek);
		}

		public Pie? GetPieById(int pieId)
		{
			return _pasteryShopContext.Pies.FirstOrDefault(p => p.PieId == pieId);
		}

		public IEnumerable<Pie> SearchPies(string searchQuery)
		{
			throw new NotImplementedException();
		}

		
	}
}
