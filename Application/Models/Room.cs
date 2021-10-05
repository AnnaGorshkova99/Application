using Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Гостиничный номер
    /// </summary>
    public class Room : EntityBase
    {
        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Категория номера
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Гостиница номера
        /// </summary>
        public Hotel Hotel { get; set; }
        /// <summary>
        /// Идентификатор гостиницы
        /// </summary>
        public Guid HotelId { get; set; }
        /// <summary>
        /// Количество мест в номере
        /// </summary>
        public int NumberOfSeats { get; set; }
        /// <summary>
        /// Клиенты в номера
        /// </summary>
        public ICollection<Client> Clients { get; set; }
    }
}
