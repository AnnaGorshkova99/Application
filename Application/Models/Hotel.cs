using Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Гостиница
    /// </summary>
    public class Hotel : EntityBase
    {
        /// <summary>
        /// Название гостиницы
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Гостиничные номера
        /// </summary>
        public ICollection<Room> HotelRooms { get; set; }
        /// <summary>
        /// Сотрудники
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
    }
}
