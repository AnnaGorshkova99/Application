using Application.Infrastructure.Repository;
using Application.Models;
using Application.Services.Repositories.RoomRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class RoomController : Controller
    {
        IRepository<Room> repository;
        IRepository<Category> categoryRepository;
        IRepository<Hotel> hotelRepository;
        IRoomRepository superRepository;

        public RoomController(IRepository<Room> repository,
            IRoomRepository superRepository,
            IRepository<Category> categoryRepository, 
            IRepository<Hotel> hotelRepository)
        {
            this.repository = repository;
            this.superRepository = superRepository;
            this.categoryRepository = categoryRepository;
            this.hotelRepository = hotelRepository;
        }

        public async Task<IActionResult> GetAdmin()
        {
            List<Room> rooms = await superRepository.GetAllWithAll();
            return View(rooms);
        }

        [HttpGet]
        public async Task<IActionResult> AddWithoutHotel()
        {
            List<Category> categories = categoryRepository.GetAll().ToList();
            ViewBag.Hotels = hotelRepository.GetAll().ToList();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddWithoutHotel(Room room)
        {
            room.Id = Guid.NewGuid();
            await repository.AddAsync(room);
            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            Hotel hotel = await hotelRepository.GetByIdAsync(id);
            List<Category> categories = categoryRepository.GetAll().ToList();
            ViewBag.Hotel = hotel;
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Room room)
        {
            room.Id = Guid.NewGuid();
            await repository.AddAsync(room);
            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Room empl = await superRepository.GetRoomByIdWithAll(id);
            List<Category> categories = categoryRepository.GetAll().ToList();
            List<Hotel> hotels = hotelRepository.GetAll().ToList();
            ViewBag.Room = empl;
            ViewBag.Hotels = hotels;
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Room empl)
        {
            if (empl == null) return NotFound();

            await repository.UpdateAsync(empl);
            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            if (id != Guid.Empty)
            {
                Room room = await repository.GetByIdAsync(id);

                if (room != null)
                {
                    await repository.DeleteAsync(room);
                    return RedirectToAction("GetAdmin");
                }
            }
            return NotFound();
        }
    }
}
