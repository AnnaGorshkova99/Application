using Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : Person
    {
        /// <summary>
        /// Специализация сотрудника
        /// </summary>
        public Specialization Specialization { get; set; }
        /// <summary>
        /// Идентификатор специализации сотрудника
        /// </summary>
        public Guid SpecializationId { get; set; }

        /// <summary>
        /// Отель сотрудника
        /// </summary>
        public Hotel Hotel { get; set; }
        /// <summary>
        /// Идентификатор отеля сотрудника
        /// </summary>
        public Guid HotelId { get; set; }
    }
}
