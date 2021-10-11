using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Repositories.ClientRepository
{
    public interface IClientRepository
    {
        Task<Client> GetByIdWithAll(Guid id);
        Task<List<Client>> GetAllWithAll();
    }
}
