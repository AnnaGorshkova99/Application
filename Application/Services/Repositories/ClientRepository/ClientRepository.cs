using Application.Infrastructure.Repository;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Repositories.ClientRepository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DbContext context) : base(context) { }

        public async Task<List<Client>> GetAllWithAll()
        {
            List<Client> empls = await GetAll().Include(e => e.Room)
                .Include(e => e.User).ToListAsync();

            return empls;
        }

        public async Task<Client> GetByIdWithAll(Guid Id)
        {
            List<Client> empls = await GetAll().Include(e => e.Room)
                .Include(e => e.User).ToListAsync();

            var h = from i in empls
                    where i.Id == Id
                    select i;

            return h.FirstOrDefault();
        }
    }
}
