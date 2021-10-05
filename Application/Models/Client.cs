using Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Client : Person
    {
        /// <summary>
        /// Гостиничный номер пользователя
        /// </summary>
        public Room Room { get; set; }
        /// <summary>
        /// Идентификатор гостиничного номер 
        /// </summary>
        public Guid RoomId { get; set; }
    }
}
