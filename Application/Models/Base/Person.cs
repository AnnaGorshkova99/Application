using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Base
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class Person : EntityBase
    {
        /// <summary>
        /// ФИО клиента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
