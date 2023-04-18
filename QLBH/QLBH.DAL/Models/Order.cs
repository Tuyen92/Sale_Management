using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal? Total { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
