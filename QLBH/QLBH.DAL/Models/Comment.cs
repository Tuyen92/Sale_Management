using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public short? Star { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
