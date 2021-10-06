using Application.Infrastructure.Repository;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(DbContext context) : base(context) { }
        public async Task<Hotel> GetHotelByIdWithAll(Guid Id)
        {
            List<Hotel> hotels = await GetAll().Include(h => h.HotelRooms).ThenInclude(r => r.Category)
                .Include(h => h.Employees).ThenInclude(e => e.Specialization).ToListAsync();

            var h = from i in hotels
                   where i.Id == Id select i;

            return h.FirstOrDefault();
        }
    }
}
