using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUser:BaseEntity
    {
        public AppUser()
        {
            Role = UserRole.Member;
            ActivationCode = Guid.NewGuid();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid ActivationCode { get; set; } //üyelik aktivasyonu için maile gelen cod
        public bool Active { get; set; } //Aktivasyondan dönen sonuç
        public string Email { get; set; }
        public UserRole Role { get; set; }


        //Relational Properties
        public virtual List<Order> Orders { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
