using QLBH.Common.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.BLL
{
    public class CommentSvc : GenericSvc<CommentRep, Comment>
    {
        #region -- Overrides --


        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        #endregion

        #region -- Methods --

        public CommentSvc() { }

        public SingleRsp GetCommentByProduct(int id)
        {
            var res = new SingleRsp();

            var m = _rep.GetCommentByProduct(id);
            res.Data = m;

            return res;
        }

        public SingleRsp AddComment(CommentReq req)
        {
            var res = new SingleRsp();

            Comment c = new Comment();
            c.UserId = req.UserId;
            c.ProductId = req.ProductId;
            c.Star = req.Star;
            c.Content = req.Content;

            var m = _rep.AddComment(c);
            res = m;

            return res;
        }

        public SingleRsp UpdateComment(int id, PutCommentReq req)
        {
            var res = new SingleRsp();

            Comment c = new Comment();
            c.Id = id;
            c.Star = req.Star;
            c.Content = req.Content;

            var m = _rep.UpdateComment(c);
            res = m;

            return res;
        }

        public SingleRsp DeleteComment(int id)
        {
            var res = new SingleRsp();

            var m = _rep.DeleteComment(id);
            res = m;

            return res;
        }

        #endregion
    }
}
