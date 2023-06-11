using Microsoft.EntityFrameworkCore;
using PasteryShop.Models;

namespace PasteryShop.Services
{
	public class PieRepository : IPieRepository
	{

		//List<Pie> pies = new List<Pie>()
		//      {
		//	new Pie
		//	{
		//		PieId = 1,
		//		Name = "Apple Pie",
		//		ShortDescription = "Delicious apple pie",
		//		LongDescription = "A classic pie made with fresh apples and a flaky crust.",
		//		Price = 12.99m,
		//		ImageUrl = "https://example.com/apple_pie.jpg",
		//		IsPieOfTheWeek = true,
		//		InStock = true,
		//		CategoryId = 1,
		//	},
		//	new Pie
		//	{
		//		PieId = 2,
		//		Name = "Pumpkin Pie",
		//		ShortDescription = "Spiced pumpkin pie",
		//		LongDescription = "A seasonal favorite made with pumpkin puree and warm spices.",
		//		Price = 10.99m,
		//		ImageUrl = "https://example.com/pumpkin_pie.jpg",
		//		IsPieOfTheWeek = false,
		//		InStock = true,
		//		CategoryId = 1,
		//	},
		//	new Pie
		//	{
		//		PieId = 3,
		//		Name = "Chocolate Pie",
		//		ShortDescription = "Rich chocolate pie",
		//		LongDescription = "A decadent pie filled with smooth chocolate filling and topped with whipped cream.",
		//		Price = 15.99m,
		//		ImageUrl = "https://example.com/chocolate_pie.jpg",
		//		IsPieOfTheWeek = false,
		//		InStock = false,
		//		CategoryId = 2,

		//	}
		//      };
		PasteryShopContext context = new PasteryShopContext();
		public IEnumerable<Pie> AllPies()
		{
			return context.Pies.Include(p=>p.Category).ToList();	
		}

		public IEnumerable<Pie> PiesOfTheWeek()
		{
			return context.Pies.Where(p => p.IsPieOfTheWeek);
		}

		public Pie? GetPieById(int pieId)
		{
			return context.Pies.FirstOrDefault(p => p.PieId == pieId);
		}

		public IEnumerable<Pie> SearchPies(string searchQuery)
		{
			throw new NotImplementedException();
		}

		
	}
}
