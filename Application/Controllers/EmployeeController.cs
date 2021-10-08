using Application.Infrastructure.Repository;
using Application.Models;
using Application.Services.Repositories.EmployeeRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class EmployeeController : Controller
    {
        IRepository<Employee> employeeRepository;
        IEmployeeRepository superEmployeeRepository;
        IRepository<Hotel> hotelRepository;
        IRepository<Specialization> specializationRepository;

        public EmployeeController(IRepository<Employee> employeeRepository,
            IRepository<Hotel> hotelRepository,
            IRepository<Specialization> specializationRepository, 
            IEmployeeRepository superEmployeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.hotelRepository = hotelRepository;
            this.specializationRepository = specializationRepository;
            this.superEmployeeRepository = superEmployeeRepository;
        }

        public async Task<IActionResult> GetAdmin()
        {
            List<Employee> list = await superEmployeeRepository.GetAllWithAll();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            Hotel hotel = await hotelRepository.GetByIdAsync(id);
            List<Specialization> specializations = specializationRepository.GetAll().ToList();
            ViewBag.Hotel = hotel;
            return View(specializations);
        }

        [HttpGet]
        public async Task<IActionResult> AddWithoutHotel()
        {
            List<Specialization> specializations = specializationRepository.GetAll().ToList();
            ViewBag.Hotels = hotelRepository.GetAll().ToList();
            return View(specializations);
        }

        [HttpPost]
        public async Task<IActionResult> AddWithoutHotel(Employee empl)
        {
            empl.Id = Guid.NewGuid();
            await employeeRepository.AddAsync(empl);
            return RedirectToAction("GetAdmin");
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee empl)
        {
            empl.Id = Guid.NewGuid();
            await employeeRepository.AddAsync(empl);
            return RedirectToAction("GetAdmin");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Employee empl = await superEmployeeRepository.GetEmplByIdWithAll(id);
            List<Specialization> specializations = specializationRepository.GetAll().ToList();
            List<Hotel> hotels = hotelRepository.GetAll().ToList();
            ViewBag.Empl = empl;
            ViewBag.Hotels = hotels;
            return View(specializations);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee empl)
        {
            if (empl == null) return NotFound();

            await employeeRepository.UpdateAsync(empl);
            return RedirectToAction("GetAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            if (id != Guid.Empty)
            {
                Employee empl = await employeeRepository.GetByIdAsync(id);

                if (empl != null)
                {
                    await employeeRepository.DeleteAsync(empl);
                    return RedirectToAction("GetAdmin");
                }
            }
            return NotFound();
        }
    }
}
