using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class OrdersDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Active { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
