using QLBH.Common.BLL;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.BLL
{
    public class RevenusSvc : GenericSvc<RevenusRep, Order>
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

        public RevenusSvc() { }

        public SingleRsp GetRevenusByYear()
        {
            var res = new SingleRsp();

            var m = _rep.GetRevenusByYear();
            res.Data = m;

            return res;
        }

        public SingleRsp GetRevenusByQuater(int y)
        {
            var res = new SingleRsp();

            var m = _rep.GetRevenusByQuater(y);
            res.Data = m;

            return res;
        }

        public SingleRsp GetRevenusByCate()
        {
            var res = new SingleRsp();

            var m = _rep.GetRevenusByCate();
            res.Data = m;

            return res;
        }

        #endregion
    }
}
