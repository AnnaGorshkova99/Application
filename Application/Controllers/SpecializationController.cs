using Application.Infrastructure.Repository;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class SpecializationController : Controller
    {
        IRepository<Specialization> repository;

        public SpecializationController(IRepository<Specialization> repository)
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
        public async Task<IActionResult> Add(Specialization spec)
        {
            if (spec == null) return NotFound();
            await repository.AddAsync(spec);
            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Specialization s = await repository.GetByIdAsync(id);
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Specialization spec)
        {
            if (spec == null) return NotFound();
            await repository.UpdateAsync(spec);
            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            if (id != Guid.Empty)
            {
                Specialization spec = await repository.GetByIdAsync(id);

                if (spec != null)
                {
                    await repository.DeleteAsync(spec);
                    return RedirectToAction("GetAdmin");
                }
            }
            return NotFound();
        }
    }
}
