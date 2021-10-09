using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class AdminController : Controller
    {

        [Authorize(Roles = "Администратор")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
