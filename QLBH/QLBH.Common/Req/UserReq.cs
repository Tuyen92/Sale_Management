using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.Common.Req
{
    public class UserReq
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string UserAddress { get; set; }
        public string Username { get; set; }
        public string Pwd { get; set; }
        public string UserRole { get; set; }
    }
}
