using FluentValidation;
using MegaOneMvc.Abstractions.Services;
using MegaOneMvc.Models;
using MegaOneMvc.Utilites.FileExtension;
using MegaOneMvc.Utilites.Validators;
using MegaOneMvc.ViewModels.Category;
using MegaOneMvc.ViewModels.Deal;
using Microsoft.AspNetCore.Mvc;

namespace MegaOneMvc.Areas.Manage.Controllers
{
    public class DealController : Controller
    {
        IDealService _db;
        DealValidator _validator;

        public DealController(IDealService db)
        {
            _db = db;
            _validator = new DealValidator();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateDeal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDealAsync(CreateDealVM dealVM)
        {
            var res = _validator.Validate(dealVM);
            if (!res.IsValid)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(dealVM);
            }

            if (!dealVM.ImgFile.CheckImgFileType())
            {
                ModelState.AddModelError("ImageFile", "Incorrect file type");
                return View();
            }

            await _db.CreateAsync(dealVM);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeleteDeal(string id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                await _db.DeleteAsync(guid);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetCategories()
        {
            return View(await _db.GetAll());
        }

        public async Task<IActionResult> UpdateCategory(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(await _db.GetById(guid));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategory(string Id, CreateDealVM DealVM)
        {
            if (!Guid.TryParse(Id, out Guid guid))
            {
                return RedirectToAction(nameof(Index));
            }

            var res = _validator.Validate(DealVM);
            if (!res.IsValid)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(DealVM);
            }

            await _db.UpdateAsync(guid, DealVM);

            return RedirectToAction(nameof(Index));
        }
    }
}
