using Application.Infrastructure.Repository;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        IRepository<Category> repository;

        public CategoryController(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> GetAdmin()
        {
            return View(repository.GetAll().ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category cat)
        {
            if (cat == null) return NotFound();
            await repository.AddAsync(cat);
            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Category s = await repository.GetByIdAsync(id);
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category cat)
        {
            if (cat == null) return NotFound();
            await repository.UpdateAsync(cat);
            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            if (id != Guid.Empty)
            {
                Category cat = await repository.GetByIdAsync(id);

                if (cat != null)
                {
                    await repository.DeleteAsync(cat);
                    return RedirectToAction("GetAdmin");
                }
            }
            return NotFound();
        }
    }
}
