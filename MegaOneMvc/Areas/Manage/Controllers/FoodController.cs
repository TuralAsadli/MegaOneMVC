using MediatR;
using MegaOneMvc.Models.Commands.Deals;
using MegaOneMvc.Models.Commands.Foods;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Models.Queries.Categories;
using MegaOneMvc.Models.Queries.Foods;
using MegaOneMvc.Utilites.FileExtension;
using MegaOneMvc.Utilites.Validators;
using MegaOneMvc.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaOneMvc.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class FoodController : Controller
    {
        IMediator _mediator;

        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _mediator.Send(new GetAllFoodQuery());
            return View(res);
        }

        public async Task<IActionResult> CreateFood()
        {
            ViewBag.Categories = new SelectList(await _mediator.Send(new GetAllCategoryQuery()), nameof(GetCategoryVM.Id), nameof(GetCategoryVM.CategoryName));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood(CreateFoodCommand food)
        {
            CreateFoodCommandValidator validator = new CreateFoodCommandValidator();
            var res = validator.Validate(food);
            if (!res.IsValid)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(food);
            }

            if (!food.ImgFile.CheckImgFileType())
            {
                ModelState.AddModelError("ImageFile", "Incorrect file type");
                return View();
            }

            await _mediator.Send(food);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeleteFood(string id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                await _mediator.Send(new DeleteFoodCommand() { Id = guid });
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public async Task<IActionResult> GetFoods()
        {
            return View(await _mediator.Send(new GetAllFoodQuery()));
        }

        public async Task<IActionResult> UpdateFood(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(await _mediator.Send(new GetAllCategoryQuery()), nameof(GetCategoryVM.Id), nameof(GetCategoryVM.CategoryName));
            var res = await _mediator.Send(new GetFoodQuery() { Id = guid });
            UpdateFoodCommand updateFood = new UpdateFoodCommand()
            {
                Id = res.Id,
                FoodName = res.FoodName,
                Description = res.Description,
                Price = res.Price,
                CategoryId = res.CategoryId

            };
            return View(updateFood);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateFood(string Id, UpdateFoodCommand food)
        {
            if (!Guid.TryParse(Id, out Guid guid))
            {
                return RedirectToAction(nameof(Index));
            }

            UpdateFoodCommandValidator validator = new UpdateFoodCommandValidator();

            var res = validator.Validate(food);
            if (!res.IsValid)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(food);
            }

            food.Id = guid;

            await _mediator.Send(food);

            return RedirectToAction(nameof(Index));
        }
    }
}
