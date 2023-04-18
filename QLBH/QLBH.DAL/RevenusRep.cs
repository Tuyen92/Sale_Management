using QLBH.Common.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.DAL
{
    public class RevenusRep : GenericRep<qlbhContext, Order>
    {
        #region -- Overrides --

        public override Order Read(int id)
        {
            var res = All.FirstOrDefault(p => p.Id == id);
            return res;
        }

        #endregion

        #region -- Methods --

        public object GetRevenusByYear()
        {
            var res = All.GroupBy(g => g.CreatedDate.Year).Select(s => new { Year = s.Key, Revenus = s.Sum(x => x.Total) });

            return res;
        }

        public object GetRevenusByQuater(int y)
        {
            var res = All.Where(w => w.CreatedDate.Year == y).GroupBy(g => (g.CreatedDate.Month + 2) / 3).Select(s => new { Quater = s.Key, Revenus = s.Sum(x => x.Total) });

            return res;
        }

        public object GetRevenusByCate()
        {
            OrdersDetailRep odRep = new OrdersDetailRep();
            ProductRep pRep = new ProductRep();
            CategoryRep cRep = new CategoryRep();
            var od = odRep.All.ToList();
            var p = pRep.All.ToList();
            var c = cRep.All.ToList();

            var res = od.Join(p, ord => ord.ProductId, pro => pro.Id, (ord, pro) => new { OrdPrice = ord.UnitPrice * ord.Amount, CategoryId = pro.CategoryId })
                        .Join(c, pOrd => pOrd.CategoryId, ct => ct.Id, (pOrd, ct) => new { OrderDetailPrice = pOrd.OrdPrice, Category = ct.Name })
                        .GroupBy(g => g.Category).Select(s => new { Category = s.Key, Revenus = s.Sum(x => x.OrderDetailPrice) });

            return res;
        }

        #endregion
    }
}
