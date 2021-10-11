using Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
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
        /// Описание отеля
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Изображение отеля
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Гостиничные номера
        /// </summary>
        [JsonIgnore]
        public ICollection<Room> HotelRooms { get; set; }
        /// <summary>
        /// Сотрудники
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
    }
}
