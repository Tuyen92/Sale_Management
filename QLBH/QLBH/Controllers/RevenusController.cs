using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenusController : ControllerBase
    {
        private readonly RevenusSvc revenusSvc;
        public RevenusController()
        {
            revenusSvc = new RevenusSvc();
        }
        // GET api/<RevenusController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = new SingleRsp();
            res = revenusSvc.Read(id);
            return Ok(res);
        }
        // GET: api/<RevenusController>
        [HttpGet]
        public IActionResult Get()
        {
            var res = new SingleRsp();
            res.Data = revenusSvc.All;
            return Ok(res);
        }
        // GET: api/<RevenusController>/by-year
        [HttpGet("by-year")]
        public IActionResult GetRevenusByYear()
        {
            var res = new SingleRsp();
            res = revenusSvc.GetRevenusByYear();
            return Ok(res);
        }
        // GET: api/<RevenusController>/by-year/2021
        [HttpGet("by-year/{y}")]
        public IActionResult GetRevenusByQuater(int y)
        {
            var res = new SingleRsp();
            res = revenusSvc.GetRevenusByQuater(y);
            return Ok(res);
        }
        // GET: api/<RevenusController>/by-year/2021
        [HttpGet("by-category")]
        public IActionResult GetRevenusByCate()
        {
            var res = new SingleRsp();
            res = revenusSvc.GetRevenusByCate();
            return Ok(res);
        }
    }
}
