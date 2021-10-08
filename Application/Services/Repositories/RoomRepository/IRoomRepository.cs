using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Repositories.RoomRepository
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomByIdWithAll(Guid Id);
        Task<List<Room>> GetAllWithAll();
    }
}
