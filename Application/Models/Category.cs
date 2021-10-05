using Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Категория номера
    /// </summary>
    public class Category : EntityBase
    {
        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Номера гостиницы данной категории
        /// </summary>
        public ICollection<Room> Rooms { get; set; }
    }
}
