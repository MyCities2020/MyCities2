using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyCities2.Models.User;

namespace MyCities2.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleUser Role { get; set; }
    }
}
