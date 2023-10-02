using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class User : BaseEntityA
    {
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
    public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}