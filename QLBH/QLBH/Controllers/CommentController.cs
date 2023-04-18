using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Rsp;
using QLBH.Common.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLBH.DAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentSvc commentSvc;
        public CommentController()
        {
            commentSvc = new CommentSvc();
        }
        // GET: api/<CommentController>
        [HttpGet]
        public IActionResult Get()
        {
            var res = new SingleRsp();
            res.Data = commentSvc.All;
            return Ok(res);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = new SingleRsp();
            res = commentSvc.Read(id);
            return Ok(res);
        }

        // GET api/<CommentController>/by-product/5
        [HttpGet("by-product/{id}")]
        public IActionResult GetByProduct(int id)
        {
            var res = new SingleRsp();
            res = commentSvc.GetCommentByProduct(id);
            return Ok(res);
        }

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Add([FromBody] CommentReq req)
        {
            var res = new SingleRsp();
            res = commentSvc.AddComment(req);
            return Ok(res);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PutCommentReq req)
        {
            var res = new SingleRsp();
            res = commentSvc.UpdateComment(id, req);
            return Ok(res);
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = new SingleRsp();
            res = commentSvc.DeleteComment(id);
            return Ok(res);
        }
    }
}
