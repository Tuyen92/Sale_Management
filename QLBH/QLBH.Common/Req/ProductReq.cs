using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.Common.Req
{
    public class ProductReq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public string Supplier { get; set; }
        public int CategoryId { get; set; }
        public decimal? Price { get; set; }
        public string Images { get; set; }
        public bool? OnSale { get; set; }
    }
}
