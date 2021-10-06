using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmplByIdWithAll(Guid Id);
        Task<List<Employee>> GetAllWithAll();
    }
}
