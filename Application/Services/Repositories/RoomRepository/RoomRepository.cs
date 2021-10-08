using Application.Infrastructure.Repository;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Repositories.RoomRepository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(DbContext context) : base(context) { }

        public async Task<List<Room>> GetAllWithAll()
        {
            return await GetAll().Include(e => e.Hotel)
                .Include(e => e.Category)
                .Include(e => e.Clients).ToListAsync();
        }

        public async Task<Room> GetRoomByIdWithAll(Guid Id)
        {
            List<Room> empls = await GetAll().Include(e => e.Hotel)
                .Include(e => e.Category)
                .Include(e => e.Clients).ToListAsync();

            var h = from i in empls
                    where i.Id == Id
                    select i;

            return h.FirstOrDefault();
        }
    }
}
