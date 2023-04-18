using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserSvc userSvc;
        public UserController()
        {
            userSvc = new UserSvc();
        }
        [HttpPost("register")]
        public IActionResult registerUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.RegisterUser(userReq);

            return Ok(res);
        }
        [HttpPost("login")]
        public IActionResult login([FromBody] User user)
        {
            var res = new SingleRsp();
            res = userSvc.Login(user);

            return Ok(res);
        }

        //add 12-09
        [HttpPost("update")]
        public ActionResult UpdateProduct([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.UpdateUser(userReq);
            return Ok(res);
        }
    }
}
