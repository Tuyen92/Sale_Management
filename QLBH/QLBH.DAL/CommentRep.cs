using QLBH.Common.DAL;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.DAL
{
    public class CommentRep : GenericRep<qlbhContext, Comment>
    {
        #region -- Overrides --

        public override Comment Read(int id)
        {
            var res = All.FirstOrDefault(p => p.Id == id);
            return res;
        }

        #endregion

        #region -- Methods --

        public object GetCommentByProduct(int id)
        {
            var res = All.Where(w => w.ProductId == id).Select(s => s).OrderByDescending(o => o.Star);

            return res;
        }

        public SingleRsp AddComment(Comment comment)
        {
            SingleRsp res = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Comments.Add(comment);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = "Successful";
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        res.SetError(e.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateComment(Comment comment)
        {
            SingleRsp res = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var c = context.Comments.Single(s => s.Id == comment.Id);
                        c.Star = comment.Star;
                        c.Content = comment.Content;
                        var p = context.Comments.Update(c);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = "Successful";
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        res.SetError(e.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteComment(int id)
        {
            SingleRsp res = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var c = context.Comments.Single(s => s.Id == id);
                        var p = context.Comments.Remove(c);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = "Successful";
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        res.SetError(e.StackTrace);
                    }
                }
            }
            return res;
        }

        #endregion
    }
}
