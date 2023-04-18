using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string UserAddress { get; set; }
        public string Username { get; set; }
        public string Pwd { get; set; }
        public string UserRole { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
