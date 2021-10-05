using Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Специализация
    /// </summary>
    public class Specialization : EntityBase
    {
        /// <summary>
        /// Название специализации
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Обязанности
        /// </summary>
        public string Responsibilities { get; set; }
        /// <summary>
        /// Сотрудники
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
    }
}
