using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWithASP.NETCore.Doima.Entities.Users
{
    public class User
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
