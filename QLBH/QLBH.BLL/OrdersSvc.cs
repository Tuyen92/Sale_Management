using QLBH.Common.BLL;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.BLL
{
    public class OrdersSvc:GenericSvc<OrdersRep, Order>
    {
        private OrdersRep ordersRep;
        public OrdersSvc()
        {
            ordersRep = new OrdersRep();
        }

        #region override
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
        #endregion

        #region method  

        public int removeOrder(int id)
        {
            return ordersRep.removeOrder(id);
        }
        public SingleRsp createOrder(Order orderrq)
        {
            var res = new SingleRsp();
            Order order = new Order();
            order.Id = orderrq.Id;
            order.Total = orderrq.Total;
            order.UserId = orderrq.Id;
            order.User = orderrq.User;
            order.OrdersDetails = orderrq.OrdersDetails;

            res = ordersRep.createOrder(orderrq);
            return res;
        }

        public SingleRsp updateOrdersDetail(Order orderrq)
        {
            var res = new SingleRsp();
            Order order = new Order();
            order.Id = orderrq.Id;
            order.Total = orderrq.Total;
            order.UserId = orderrq.Id;
            order.User = orderrq.User;
            order.OrdersDetails = orderrq.OrdersDetails;

            res = ordersRep.updateOrder(orderrq);
            return res;
        }
        #endregion
    }
}
