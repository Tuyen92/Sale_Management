using QLBH.Common.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Helpers;

namespace QLBH.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        private UserRep userRep;
        public UserSvc()
        {
            userRep = new UserRep();
        }

        #region Override
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
       
        #endregion
        #region methods
        public SingleRsp RegisterUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
         
            user.FirstName = userReq.FirstName;
            user.LastName = userReq.LastName;
            user.Username = userReq.Username;
            user.Phone = userReq.Phone;
            user.UserAddress = userReq.UserAddress;
            user.Pwd = userReq.Pwd;
            user.UserRole = "CS";
            res = userRep.RegisterUser(user);
            return res;
        }

        public SingleRsp Login(User user)
        {
            var res = new SingleRsp();
            res = userRep.Login(user);
            return res;
        }
        //add 12-09
        public SingleRsp GetAllUser()
        {
            var singleRsp = new SingleRsp();
            singleRsp = userRep.GetAllUser();
            return singleRsp;
        }

        public SingleRsp UpdateUser(UserReq userReq)
        {
            var singleRsp = new SingleRsp();
            User u = _rep.Read(userReq.Id);
            if (!string.IsNullOrEmpty(userReq.Username))
            {
                u.Username = userReq.Username;
            }
            if (!string.IsNullOrEmpty(userReq.Pwd))
            {
                u.Pwd = userReq.Pwd;
            }
            if (!string.IsNullOrEmpty(userReq.Phone))
            {
                u.Phone = userReq.Phone;
            }
            if (!string.IsNullOrEmpty(userReq.UserAddress))
            {
                u.UserAddress = userReq.UserAddress;
            }

            singleRsp = userRep.UpdateUser(u);
            return singleRsp;
        }
        public SingleRsp UpdateRoleUser(UserReq userReq)
        {
            var singleRsp = new SingleRsp();
            User u = _rep.Read(userReq.Id);

            if (!string.IsNullOrEmpty(userReq.UserRole))
            {
                u.UserRole = userReq.UserRole;
            }

            singleRsp = userRep.UpdateUser(u);
            return singleRsp;
        }
        #endregion
    }
}
