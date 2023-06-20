using MediatR;
using MegaOneMvc.Models;
using MegaOneMvc.Models.Commands.Bookings;
using MegaOneMvc.Models.Queries.Categories;
using MegaOneMvc.Models.Queries.Deals;
using MegaOneMvc.Models.Queries.Foods;
using MegaOneMvc.Utilites.Email;
using MegaOneMvc.Utilites.Validators;
using MegaOneMvc.ViewModels.Food;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MegaOneMvc.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        readonly IMediator _medator;
        private IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IMediator medator, IConfiguration configuration)
        {
            _logger = logger;
            _medator = medator;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _medator.Send(new GetAllCategoryQuery());
            var Foods = await _medator.Send(new GetAllFoodQuery());
            var deals = await _medator.Send(new GetAllDealsQuery());
            IndexPageVm foodsWithCategories = new IndexPageVm()
            {
                Foods = Foods.ToList(),
                Categories = categories,
                Deals = deals
                
            };
            
            return View(foodsWithCategories);
        }

       [HttpPost]
        public async Task<IActionResult> Index(CreateBookingCommand createBooking)
        {
            EmailManager emailManager = new EmailManager(configuration);
            emailManager.SendEmail(createBooking.Email, createBooking.Name, createBooking.Date, createBooking.Hour);
            CreateBookingCommandValidator _validator = new CreateBookingCommandValidator();
            var res = _validator.Validate(createBooking);
            if (!res.IsValid)
            {
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                var Categories = await _medator.Send(new GetAllCategoryQuery());
                var Foods = await _medator.Send(new GetAllFoodQuery());
                var Deals = await _medator.Send(new GetAllDealsQuery());
                IndexPageVm indexPageVm = new IndexPageVm()
                {
                    Foods = Foods.ToList(),
                    Categories = Categories,
                    Deals = Deals,
                    Booking = createBooking

                };
                return RedirectToAction(nameof(Index), indexPageVm);
            }

            await _medator.Send(createBooking);
            var categories = await _medator.Send(new GetAllCategoryQuery());
            var foods = await _medator.Send(new GetAllFoodQuery());
            var deals = await _medator.Send(new GetAllDealsQuery());
            IndexPageVm foodsWithCategories = new IndexPageVm()
            {
                Foods = foods.ToList(),
                Categories = categories,
                Deals = deals

            };
            return RedirectToAction(nameof(Index), foodsWithCategories);
        }



    }
}