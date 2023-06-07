using MediatR;
using MegaOneMvc.Models;
using MegaOneMvc.Models.Queries.Categories;
using MegaOneMvc.Models.Queries.Deals;
using MegaOneMvc.Models.Queries.Foods;
using MegaOneMvc.ViewModels.Food;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MegaOneMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IMediator _medator;

        public HomeController(ILogger<HomeController> logger, IMediator medator)
        {
            _logger = logger;
            _medator = medator;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _medator.Send(new GetAllCategoryQuery());
            var Foods = await _medator.Send(new GetAllFoodQuery());
            var deals = await _medator.Send(new GetAllDealsQuery());
            GetAllModelsVM foodsWithCategories = new GetAllModelsVM()
            {
                Foods = Foods.ToList(),
                Categories = categories,
                Deals = deals
                
            };
            
            return View(foodsWithCategories);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}