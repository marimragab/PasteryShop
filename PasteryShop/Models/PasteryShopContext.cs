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

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PasteryShop;Integrated Security=True;TrustServerCertificate=true");
		//}

	}
}
