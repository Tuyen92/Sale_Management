using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;

namespace QLBH.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrdersSvc ordersSvc;
        public OrdersController()
        {
            ordersSvc = new OrdersSvc();
        }

        [HttpPost("GetOrder-byID")]
        public IActionResult getOrderbyID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = ordersSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpDelete("Remove-Order-byID")]
        public IActionResult removeOrderbyID([FromBody] SimpleReq simpleReq)
        {
            var res = ordersSvc.removeOrder(simpleReq.Id);
            return Ok(res);
        }

        [HttpPost("Create-Order")]
        public IActionResult CreateOrdersDetail([FromBody] Order req)
        {
            var res = new SingleRsp();
            res = ordersSvc.createOrder(req);
            return Ok(res);
        }

        [HttpPost("Update-Order")]
        public IActionResult updateOrder([FromBody] Order req)
        {
            var res = new SingleRsp();
            res = ordersSvc.updateOrdersDetail(req);
            return Ok(res);
        }
    }
}