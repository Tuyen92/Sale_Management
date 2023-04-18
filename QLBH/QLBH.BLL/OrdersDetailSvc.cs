using QLBH.Common.BLL;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.BLL
{
    public class OrdersDetailSvc:GenericSvc<OrdersDetailRep, OrdersDetail>
    {
        private OrdersDetailRep ordersDetailRep;
        public OrdersDetailSvc()
        {
            ordersDetailRep = new OrdersDetailRep();
        }
        #region override
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        //public SingleRsp removeOrdersDetail(int id)
        //{
        //    var res = new SingleRsp();
        //    res = ordersDetailRep.removeOrdersDetail(id);
        //    return res;
        //}
        #endregion

        #region method  

        public int removeOrdersDetail(int id)
        {
            return ordersDetailRep.removeOrdersDetail(id);
        }
        public SingleRsp createOrdersDetail(OrdersDetail ordersDetailrq)
        {
            var res = new SingleRsp();
            OrdersDetail ordersDetail = new OrdersDetail();
            ordersDetail.Id = ordersDetailrq.Id;
            ordersDetail.OrderId = ordersDetailrq.OrderId;
            ordersDetail.ProductId = ordersDetailrq.ProductId;
            ordersDetail.UnitPrice = ordersDetailrq.UnitPrice;
            ordersDetail.Amount = ordersDetailrq.Amount;
            ordersDetail.Active = ordersDetailrq.Active;
            
            res = ordersDetailRep.createOrdersDetail(ordersDetailrq);

            return res;
        }

        public SingleRsp updateOrdersDetail(OrdersDetail ordersDetailrq)
        {
            var res = new SingleRsp();
            OrdersDetail ordersDetail = new OrdersDetail();
            ordersDetail.Id = ordersDetailrq.Id;
            ordersDetail.OrderId = ordersDetailrq.OrderId;
            ordersDetail.ProductId = ordersDetailrq.ProductId;
            ordersDetail.UnitPrice = ordersDetailrq.UnitPrice;
            res = ordersDetailRep.updateOrdersDetail(ordersDetailrq);

            return res;
        }
        #endregion
    }
}
