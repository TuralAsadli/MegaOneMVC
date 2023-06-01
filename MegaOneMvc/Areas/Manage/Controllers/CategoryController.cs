﻿using MediatR;
using MegaOneMvc.Abstractions.Services;
using MegaOneMvc.Models.Commands.Categories;
using MegaOneMvc.Models.Queries.Categories;
using MegaOneMvc.Utilites.FileExtension;
using MegaOneMvc.Utilites.Validators;
using Microsoft.AspNetCore.Mvc;

namespace MegaOneMvc.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        ICategoryService _db;

        IMediator _mediator;
        public CategoryController(ICategoryService db, IMediator mediator)
        {
            _db = db;

            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _mediator.Send(new GetAllCategoryQuery());
            return View(res);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategory)
        {
            if (!createCategory.ImageFile.CheckImgFileType())
            {
                ModelState.AddModelError("ImageFile", "Incorrect file type");
                return View();
            }

            CreateCategoryCommandValidator validator = new CreateCategoryCommandValidator();
            var res = validator.Validate(createCategory);
            if (!res.IsValid)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(createCategory);
            }
            await _mediator.Send(createCategory);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                await _mediator.Send(new DeleteCategoryCommand());
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }


        public async Task<IActionResult> UpdateCategory(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(await _mediator.Send(new GetCategoryQuery() { Id = guid }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(string Id, UpdateCategoryCommand Category)
        {
            if (!Guid.TryParse(Id, out Guid guid))
            {
                return RedirectToAction(nameof(Index));
            }

            var validator = new UpdateCategoryCommandValidation();
            var res = validator.Validate(Category);
            if (!res.IsValid)
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(Category);
            }

            Category.Id = guid;

            await _mediator.Send(Category);

            return RedirectToAction(nameof(Index));
        }
    }
}