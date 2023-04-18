using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers
{
    [Route("admin/")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private UserSvc userSvc;
        public AdminController()
        {
            userSvc = new UserSvc();
        }
        [HttpGet("")]
        public ActionResult GetAllUser()
        {
            var res = new SingleRsp();
            res = userSvc.GetAllUser();
            return Ok(res);
        }
        [HttpPut("update/user")]
        public ActionResult UpdateRolelUser(UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.UpdateRoleUser(userReq);
            return Ok(res);
        }

    }
}
