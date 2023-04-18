using QLBH.Common.DAL;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.DAL
{
    public class OrdersDetailRep:GenericRep<qlbhContext,OrdersDetail>
    {
        public OrdersDetailRep()
        {

        }
        #region Override
        public override OrdersDetail Read(int id)
        {
            var res = All.FirstOrDefault(c => c.Id == id); 
            return res;
        }

       
        
        #endregion

        #region Method
        public SingleRsp createOrdersDetail(OrdersDetail ordersDetail)
        {
            var res = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using(var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.OrdersDetails.Add(ordersDetail);                       
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

        public int removeOrdersDetail(int id)
        {
            var res = new SingleRsp();
            
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var itemRemove = All.First(x => x.Id == id);
                        context.OrdersDetails.Remove(itemRemove);
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

        public SingleRsp updateOrdersDetail(OrdersDetail ordersDetail)
        {
            var res = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var od = context.OrdersDetails.Update(ordersDetail);
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


        #endregion
    }
}
