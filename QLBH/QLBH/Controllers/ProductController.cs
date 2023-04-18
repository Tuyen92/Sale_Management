using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }

        //Lấy danh sách tất cả sản phẩm
        [HttpGet("")]
        public ActionResult GetAllProducts()
        {
            var res = new SingleRsp();
            res = productSvc.GetAllProducts();
            return Ok(res);
        }

        //Lấy danh sách sản phẩm theo loại
        [HttpGet("categoryID")]
        public ActionResult GetProductsByCategory([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productSvc.GetAllProductsByCategory(simpleReq.Id);
            return Ok(res);
        }

        //Lấy sản phẩm theo nhà cung cấp
        [HttpPost("supplier")]
        public ActionResult GetAllProductsBySupplier([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.GetAllProductsBySupplier(productReq.Supplier);
            return Ok(res);
        }

        //Lấy sản phẩm theo mã sản phẩm
        [HttpPost("id")]
        public ActionResult GetProductByID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        //Tìm sản phẩm theo tên
        [HttpPost("name")]
        public ActionResult GetProductsByName([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.GetAllProductsByName(productReq.Name);
            return Ok(res);
        }

        //Tìm sản phẩm theo giá
        [HttpPost("price")]
        public ActionResult GetAllProductsByPrice([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.GetAllProductsByPrice((decimal)productReq.Price);
            return Ok(res);
        }

        internal ActionResult DeleteProductByCategory(int id)
        {
            throw new NotImplementedException();
        }

        //Lấy danh sách sản phẩm giảm giá
        [HttpGet("onSale")]
        public ActionResult GetProductsByOnSale()
        {
            var res = new SingleRsp();
            res = productSvc.GetAllProductsByOnSale();
            return Ok(res);
        }

        //Đếm tổng số lượng sản phẩm -- AD, EM
        [HttpGet("count")]
        //[Authorize(Roles = "AD, EM")]
        public ActionResult CountProduct()
        {
            int c = productSvc.CountProduct();
            return Ok(c);
        }

        //Đếm số lượng sản phẩm theo loại -- AD, EM
        [HttpGet("countByCategory")]
        //[Authorize(Roles = "AD, EM")]
        public ActionResult CountProductByCategory([FromBody] ProductReq productReq)
        {
            int c = productSvc.CountProductByCategory(productReq.CategoryId);
            return Ok(c);
        }

        //Đếm số lượng sản phẩm theo nhà cung cấp -- AD, EM
        [HttpGet("countBySupplier")]
        //[Authorize(Roles = "AD, EM")]
        public ActionResult CountProductBySupplier([FromBody] ProductReq productReq)
        {
            int c = productSvc.CountProductBySupplier(productReq.Supplier);
            return Ok(c);
        }

        //Thêm mới sản phẩm -- AD
        [HttpPost("add")]
        //[Authorize(Roles = "AD")]
        public IActionResult AddProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.AddProduct(productReq);
            return Ok(res);
        }

        //Cập nhật sản phẩm -- AD
        [HttpPut("update")]
        //[Authorize(Roles = "AD")]
        public ActionResult UpdateProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.UpdateProduct(productReq);
            return Ok(res);
        }

        //Cập nhật giảm giá sản phẩm -- AD
        [HttpPut("updateOnSale")]
        //[Authorize(Roles = "AD")]
        public ActionResult UpdateProductOnSale([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.UpdateProductOnSale(productReq);
            return Ok(res);
        }

        //Xóa sản phẩm -- AD
        [HttpDelete("delete")]
        //[Authorize(Roles = "AD")]
        public ActionResult DeleteProduct([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productSvc.DeleteProduct(simpleReq.Id);
            return Ok(res);
        }

        //Xóa các sản phẩm theo loại -- AD
        [HttpDelete("deleteByCategory")]
        //[Authorize(Roles = "AD")]
        public ActionResult DeleteProductByCategory([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productSvc.DeleteProductByCategory(simpleReq.Id);
            return Ok(res);
        }
    }
}
