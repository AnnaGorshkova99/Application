using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.ViewModels
{
    public class EditUserRoleModel
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }
    }
}
