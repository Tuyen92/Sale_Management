using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;
        private ProductSvc productSvc;
        public CategoryController()
        {
            categorySvc = new CategorySvc();
            productSvc = new ProductSvc();
        }

        //Lấy loại sản phẩm theo mã loại sản phẩm
        [HttpPost("id")]
        public ActionResult GetCategoryByID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(simpleReq.Id);
            return Ok(res);
        }

        //Lấy danh sách loại sản phẩm
        [HttpGet("")]
        public ActionResult GetAllCategory()
        {
            var res = new SingleRsp();
            res = categorySvc.GetAllCategory();
            return Ok(res);
        }

        //Thêm mới loại sản phẩm
        [HttpPost("add")]
        public IActionResult AddCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.AddCategory(categoryReq);
            return Ok(res);
        }

        //Cập nhật loại sản phẩm
        [HttpPut("update")]
        public ActionResult UpdateCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.UpdateCategory(categoryReq);
            return Ok(res);
        }

        //Xóa loại sản phẩm
        [HttpDelete("delete")]
        public ActionResult DeleteCategory([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = categorySvc.Remove(simpleReq.Id);
            return Ok(res);
        }

        //Xóa loại sản phẩm kèm theo các sản phẩm loại đó
        [HttpDelete("deleteWithAllProducts")]
        public ActionResult DeleteCategoryAndProducts([FromBody] SimpleReq simpleReq)
        {
            var resP = new SingleRsp();
            var resC = new SingleRsp();
            resP = productSvc.DeleteProductByCategory(simpleReq.Id);
            resC = categorySvc.Remove(simpleReq.Id);
            return Ok(resC);
        }
    }
}
