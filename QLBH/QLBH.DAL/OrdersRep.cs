using QLBH.Common.DAL;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.DAL
{
    public class OrdersRep: GenericRep<qlbhContext, Order>
    {
        public OrdersRep(){
        
        }

        public override Order Read(int id)
        {
            var res = All.FirstOrDefault(c => c.Id == id);
            return res;
        }

        public int removeOrder(int id)
        {
            var res = new SingleRsp();

            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var itemRemove = All.First(x => x.Id == id);
                        context.Orders.Remove(itemRemove);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return id;
        }

        public SingleRsp createOrder(Order order)
        {
            var res = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Add(order);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp updateOrder(Order order)
        {
            var res = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Update(order);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
