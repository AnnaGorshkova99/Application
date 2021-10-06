using Application.Infrastructure.Repository;
using Application.Models;
using Application.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class HotelController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelRepository superHotelRepository;
        private readonly IRepository<Hotel> hotelRepository;

        public HotelController(ILogger<HomeController> logger, 
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

        public IActionResult GetAdmin()
        {
            return View(hotelRepository.GetAll().ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty) return RedirectToAction("Index");
            Hotel hotel = await superHotelRepository.GetHotelByIdWithAll(id);
            return View(hotel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Hotel hotel)
        {
            hotel.Employees = new List<Employee>();
            hotel.HotelRooms = new List<Room>();
            await hotelRepository.AddAsync(hotel);
            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id != Guid.Empty)
            {
                Hotel hotel = await superHotelRepository.GetHotelByIdWithAll(id);
                return View(hotel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Hotel hotel)
        {
            if (hotel == null) return NotFound();

            await hotelRepository.UpdateAsync(hotel);
            return RedirectToAction("GetAdmin");

        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            if(id != Guid.Empty)
            {
                Hotel hotel = await hotelRepository.GetByIdAsync(id);

                if (hotel != null)
                {
                    await hotelRepository.DeleteAsync(hotel);
                    return RedirectToAction("GetAdmin");
                }
            }
            return NotFound();
        }
    }
}
