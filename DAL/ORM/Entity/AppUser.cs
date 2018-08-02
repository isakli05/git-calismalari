using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Entity
{
    public enum Roles
    {
        None = 0,
        Member = 1,
        Admin = 3,
    }

    public class AppUser:BaseEntity
    {
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Roles Role { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Email { get; set; }
    }
}
