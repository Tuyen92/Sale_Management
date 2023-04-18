using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public string Descriptions { get; set; }
        public decimal? Price { get; set; }
        public string Images { get; set; }
        public bool? OnSale { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
