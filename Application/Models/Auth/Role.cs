using Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Auth
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; } 

        public Role()
        {
            Clients = new List<Client>();
        }
    }
}
