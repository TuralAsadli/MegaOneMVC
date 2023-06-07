using MediatR;
using MegaOneMvc.Abstractions.Services;
using MegaOneMvc.Models.Commands.Categories;
using MegaOneMvc.Models.Commands.Deals;
using MegaOneMvc.Models.Queries.Categories;
using MegaOneMvc.Models.Queries.Deals;
using MegaOneMvc.Utilites.FileExtension;
using MegaOneMvc.Utilites.Validators;
using Microsoft.AspNetCore.Mvc;

namespace MegaOneMvc.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DealController : Controller
    {
        

        IMediator _mediator;

        public DealController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _mediator.Send(new GetAllDealsQuery());
            return View(res);
        }

        public IActionResult CreateDeal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeal(CreateDealCommand deal)
        {
            CreateDealCommandValidator validator = new CreateDealCommandValidator();
            var res = validator.Validate(deal);
            if (!res.IsValid)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(deal);
            }

            if (!deal.ImgFile.CheckImgFileType())
            {
                ModelState.AddModelError("ImageFile", "Incorrect file type");
                return View();
            }

            await _mediator.Send(deal);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeleteDeal(string id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                await _mediator.Send(new DeleteDealCommand() { Id = guid });
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        

        public async Task<IActionResult> UpdateDeal(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                return RedirectToAction(nameof(Index));
            }
            var res = await _mediator.Send(new GetDealQuery() { Id = guid });
            UpdateDealCommand updateDeal = new UpdateDealCommand()
            {
                Id = res.Id,
                DealName = res.DealName,
                Description = res.Description,
                Price = res.Price

            };
            return View(updateDeal);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateDeal(string Id, UpdateDealCommand Deal)
        {
            if (!Guid.TryParse(Id, out Guid guid))
            {
                return RedirectToAction(nameof(Index));
            }

            UpdateDealCommandValidator validator = new UpdateDealCommandValidator();

            var res = validator.Validate(Deal);
            if (!res.IsValid)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(Deal);
            }

            Deal.Id = guid;

            await _mediator.Send(Deal);

            return RedirectToAction(nameof(Index));
        }
    }
}
