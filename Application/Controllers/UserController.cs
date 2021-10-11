using Application.Infrastructure.Repository;
using Application.Models;
using Application.Models.ViewModels;
using Application.Services.Repositories.ClientRepository;
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
    public class UserController : Controller
    {
        IClientRepository superRepository;
        IRepository<Client> repository;
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;
        public UserController(IClientRepository superRepository,
            IRepository<Client> repository,
            RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager)
        {
            this.superRepository = superRepository;
            this.repository = repository;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetAdmin()
        {
            List<Client> clients = await superRepository.GetAllWithAll();
            return View(clients);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Client client = await repository.GetByIdAsync(id);
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View(new EditUserRoleModel() { UserId = client.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserRoleModel model)
        {
            if (model == null) return NotFound();

            Client user = await superRepository.GetByIdWithAll(model.UserId);

            var userRoles = await _userManager.GetRolesAsync(user.User);

            if (userRoles != null)
            {
                await _userManager.RemoveFromRolesAsync(user.User, userRoles);
            }
                

            await _userManager.AddToRolesAsync(user.User, new List<string> { model.Role });

            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            if (id != Guid.Empty)
            {
                Client empl = await superRepository.GetByIdWithAll(id);

                if (empl != null)
                {
                    await _userManager.DeleteAsync(empl.User);
                    await repository.DeleteAsync(empl);
                    return RedirectToAction("GetAdmin");
                }
            }
            return NotFound();
        }
    }
}
