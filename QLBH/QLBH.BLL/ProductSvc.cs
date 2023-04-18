using QLBH.Common.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.BLL
{
    public class ProductSvc:GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;
        private CategoryRep categoryRep;
        public ProductSvc()
        {
            productRep = new ProductRep();
            categoryRep = new CategoryRep();
        }

        //Lấy danh sách tất cả sản phẩm
        public SingleRsp GetAllProducts()
        {
            var singleRsp = new SingleRsp();
            singleRsp = productRep.GetAllProducts();
            return singleRsp;
        }

        //Lấy danh sách sản phẩm theo loại
        public SingleRsp GetAllProductsByCategory(int id)
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = productRep.GetAllProductsByCategory(id);
            return singleRsp;
        }

        //Lấy sản phẩm theo nhà cung cấp
        public SingleRsp GetAllProductsBySupplier(String name)
        {
            var singleRsp = productRep.GetAllProductsBySupplier(name);
            return singleRsp;
        }

        //Lấy sản phẩm theo mã sản phẩm
        public override SingleRsp Read(int id)
        {
            var singleRes = new SingleRsp();
            singleRes.Data = _rep.Read(id);
            return singleRes;
        }

        //Tìm sản phẩm theo tên
        public SingleRsp GetAllProductsByName(String name)
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = productRep.GetAllProductsByName(name);
            return singleRsp;
        }

        //Tìm sản phẩm theo giá
        public SingleRsp GetAllProductsByPrice(decimal price)
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = productRep.GetAllProductsByPrice(price);
            return singleRsp;
        }

        //Lấy danh sách sản phẩm giảm giá
        public SingleRsp GetAllProductsByOnSale()
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = productRep.GetAllProductsByOnSale();
            return singleRsp;
        }

        //Đếm tổng số lượng sản phẩm
        public int CountProduct()
        {
            return productRep.CountProduct();
        }

        //Đếm số lượng sản phẩm theo loại
        public int CountProductByCategory(int id)
        {
            return productRep.CountProductByCategory(id);
        }

        //Đếm số lượng sản phẩm theo nhà cung cấp
        public int CountProductBySupplier(String name)
        {
            return productRep.CountProductBySupplier(name);
        }

        //Thêm mới sản phẩm
        public SingleRsp AddProduct(ProductReq productReq)
        {
            var singleRsp = new SingleRsp();
            Product p = new Product();
            p.Name = productReq.Name;
            p.Supplier = productReq.Supplier;
            p.CategoryId = productReq.CategoryId;
            //p.Category = categoryRep.Read(productReq.CategoryId);
            if (!string.IsNullOrEmpty(productReq.Descriptions))
            {
                p.Descriptions = productReq.Descriptions;
            }
            else
            {
                p.Descriptions = "Chưa có thông tin";
            }
            if (productReq.Price.HasValue == true)
            {
                p.Price = productReq.Price;
            }
            else
            {
                p.Price = 0;
            }
            if (!string.IsNullOrEmpty(productReq.Images))
            {
                p.Images = productReq.Images;
            }
            else
            {
                p.Images = "Chưa có thông tin";
            }
            p.OnSale = false;
            singleRsp = productRep.AddProduct(p);
            return singleRsp;
        }

        //Cập nhật sản phẩm
        public SingleRsp UpdateProduct(ProductReq productReq)
        {
            var singleRsp = new SingleRsp();
            Product p = _rep.Read(productReq.Id);
            if (!string.IsNullOrEmpty(productReq.Name))
            {
                p.Name = productReq.Name;
            }
            if (!string.IsNullOrEmpty(productReq.Supplier))
            {
                p.Supplier = productReq.Supplier;
            }
            if (!string.IsNullOrEmpty(productReq.Descriptions))
            {
                p.Descriptions = productReq.Descriptions;
            }
            if (!string.IsNullOrEmpty(productReq.Images))
            {
                p.Images = productReq.Images;
            }
            if (productReq.Price != null)
            {
                p.Price = productReq.Price;
            }
            singleRsp = productRep.UpdateProduct(p);
            return singleRsp;
        }

        //Cập nhật giảm giá sản phẩm
        public SingleRsp UpdateProductOnSale(ProductReq productReq)
        {
            var singleRsp = new SingleRsp();
            Product p = _rep.Read(productReq.Id);
            singleRsp = productRep.UpdateProductOnSale(p);
            return singleRsp;
        }

        //Xóa sản phẩm
        public SingleRsp DeleteProduct(int id)
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = productRep.DeleteProduct(id);
            return singleRsp;
        }

        //Xóa các sản phẩm theo loại
        public SingleRsp DeleteProductByCategory(int id)
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = productRep.DeleteProductByCategory(id);
            return singleRsp;
        }
    }
}
