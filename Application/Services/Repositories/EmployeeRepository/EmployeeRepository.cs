using Application.Infrastructure.Repository;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Repositories.EmployeeRepository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context) { }

        public async Task<List<Employee>> GetAllWithAll()
        {
            return await GetAll().Include(e => e.Hotel)
                .Include(e => e.Specialization).ToListAsync();
        }

        public async Task<Employee> GetEmplByIdWithAll(Guid Id)
        {
            List<Employee> empls = await GetAll().Include(e => e.Hotel)
                .Include(e => e.Specialization).ToListAsync();

            var h = from i in empls
                    where i.Id == Id
                    select i;

            return h.FirstOrDefault();
        }
    }
}
