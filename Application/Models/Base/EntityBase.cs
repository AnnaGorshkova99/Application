using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Base
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
