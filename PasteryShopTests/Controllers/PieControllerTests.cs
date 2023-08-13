using Microsoft.AspNetCore.Mvc;
using PasteryShop.Controllers;
using PasteryShop.ViewModel;
using PasteryShopTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteryShopTests.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnAllPies()
        {
            var mockPieRepository=RepositoryMocks.GetPieRepository();
            var mockCategoryRepository=RepositoryMocks.GetCategoryRepository();
            var pieController=new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

            var result = pieController.List("");

            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel=Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(10, pieListViewModel.Pies.Count());
        }
    }
}
