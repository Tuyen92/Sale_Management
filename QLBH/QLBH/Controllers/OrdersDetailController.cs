using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;

namespace QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersDetailController : ControllerBase
    {
        private OrdersDetailSvc ordersDetailSvc;
        public OrdersDetailController()
        {
            ordersDetailSvc = new OrdersDetailSvc();
        }

        [HttpPost("GetOrdersDetail-byID")]
        public IActionResult getOrdersDetailbyID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = ordersDetailSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpDelete("Remove-OrdersDetail-byID")]
        public IActionResult removeOrdersDetailbyID([FromBody] SimpleReq simpleReq)
        {
            var res = ordersDetailSvc.removeOrdersDetail(simpleReq.Id);
            return Ok(res);
        }

        [HttpPost("Create-OrdersDetail")]
        public IActionResult CreateOrdersDetail([FromBody] OrdersDetail req)
        {
            var res = new SingleRsp();
            res = ordersDetailSvc.createOrdersDetail(req);
            return Ok(res);
        }

        [HttpPost("Update-OrdersDetail")]
        public IActionResult updateOrdersDetail([FromBody] OrdersDetail req)
        {
            var res = new SingleRsp();
            res = ordersDetailSvc.updateOrdersDetail(req);
            return Ok(res);
        }
    }
}