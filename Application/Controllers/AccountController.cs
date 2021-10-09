using Application.Infrastructure.Repository;
using Application.Models;
using Application.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class AccountController : Controller
    {
        private IRepository<Client> repository;
        private IRepository<Role> roleRepository;
        public AccountController(IRepository<Client> repository, 
            IRepository<Role> roleRepository)
        {
            this.repository = repository;
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Client user = repository.GetAllFiltered(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Hotel");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Client user = repository.GetAllFiltered(u => u.Email == model.Email).FirstOrDefault();
                if (user == null)
                {
                    user = new Client { Email = model.Email, Password = model.Password, Name = model.Name, PhoneNumber = model.PhoneNumber, RoleId = Guid.Parse("729a562d-5a35-4219-be9d-2ac3a6a0a260") };
                    Role userRole = null;
                    if (user.Email == "xventruxx@mail.ru")
                    {
                        userRole = roleRepository.GetAllFiltered(r => r.Name == "Администратор").FirstOrDefault();
                    }
                    else
                    {
                        userRole = roleRepository.GetAllFiltered(r => r.Name == "Пользователь").FirstOrDefault();
                    }
                    
                    if (userRole != null)
                        user.Role = userRole;

                    // добавляем пользователя в бд
                    await repository.AddAsync(user);

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Hotel");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(Client user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
