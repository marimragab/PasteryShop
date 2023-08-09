using Microsoft.AspNetCore.Mvc;
using PasteryShop.Services;

namespace PasteryShop.Components
{
    public class CategoryMenu:ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories=_categoryRepository.AllCategories()
                .OrderBy(c=>c.Name);

            return  View(categories);
        }
    }
}
