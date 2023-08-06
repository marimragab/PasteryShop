using Microsoft.EntityFrameworkCore;
using PasteryShop.Models;
using PasteryShop.Services;

namespace PasteryShop
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<PasteryShopContext>(options =>
			{
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("PasteryShopDbConnection"));
			});	

			builder.Services.AddScoped<IPieRepository, PieRepository>();
			builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			DbInitializer.Seed(app);
			app.Run();
		}
	}
}