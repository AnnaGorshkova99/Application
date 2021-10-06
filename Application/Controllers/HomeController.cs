using Application.Infrastructure.Repository;
using Application.Models;
using Application.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelRepository superHotelRepository;
        private readonly IRepository<Hotel> hotelRepository;


        public HomeController(ILogger<HomeController> logger,
            IHotelRepository superHotelRepository, 
            IRepository<Hotel> hotelRepository)
        {
            _logger = logger;
            this.superHotelRepository = superHotelRepository;
            this.hotelRepository = hotelRepository;
        }

        public IActionResult Index()
        {
            return View(hotelRepository.GetAll().ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Hotel(Guid id)
        {
            if (id == Guid.Empty) return RedirectToAction("Index");
            Hotel hotel = await superHotelRepository.GetHotelByIdWithAll(id);
            return View(hotel);
        }
    }
}
