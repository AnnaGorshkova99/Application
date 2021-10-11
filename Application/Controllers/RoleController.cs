using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult GetAdmin()
        {
            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IdentityRole hotel)
        {
            if (!string.IsNullOrEmpty(hotel.Name))
            {
                IdentityResult result = await _roleManager.CreateAsync(hotel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                IdentityRole r = await _roleManager.FindByIdAsync(id);

                if (r != null)
                {
                    await _roleManager.DeleteAsync(r);
                    return RedirectToAction("GetAdmin");
                }
            }
            return NotFound();
        }
    }
}
