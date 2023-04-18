using QLBH.Common.DAL;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.DAL
{
    public class ProductRep:GenericRep<qlbhContext,Product>
    {
        public ProductRep()
        {

        }

        //Lấy danh sách tất cả sản phẩm
        public SingleRsp GetAllProducts()
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = All;
            return singleRsp;
        }

        //Lấy danh sách sản phẩm theo loại
        public SingleRsp GetAllProductsByCategory(int id)
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = All.Where(p => p.CategoryId == id);
            return singleRsp;
        }

        //Lấy sản phẩm theo nhà cung cấp
        public SingleRsp GetAllProductsBySupplier(String name)
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = All.Where(p => p.Supplier.Contains(name));
            return singleRsp;
        }

        //Lấy sản phẩm theo mã sản phẩm
        public override Product Read(int id)
        {
            var listProduct = All.FirstOrDefault(c => c.Id == id);
            return listProduct;
        }

        //Tìm sản phẩm theo tên
        public SingleRsp GetAllProductsByName(String name)
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = All.Where(p => p.Name.Contains(name));
            return singleRsp;
        }

        //Tìm sản phẩm theo giá
        public SingleRsp GetAllProductsByPrice(decimal price)
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = All.Where(p => p.Price <= price);
            return singleRsp;
        }

        //Lấy danh sách sản phẩm giảm giá
        public SingleRsp GetAllProductsByOnSale()
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = All.Where(p => p.OnSale != null);
            return singleRsp;
        }

        //Đếm tổng số lượng sản phẩm
        public int CountProduct()
        {
            int count = 0;
            var listProduct = All;
            foreach(var m in listProduct)
            {
                count++;
            }
            return count;
        }

        //Đếm số lượng sản phẩm theo loại
        public int CountProductByCategory(int id)
        {
            int count = 0;
            var listProduct = All.Where(i => i.CategoryId == id);
            foreach (var m in listProduct)
            {
                count++;
            }
            return count;
        }

        //Đếm số lượng sản phẩm theo nhà cung cấp
        public int CountProductBySupplier(String name)
        {
            int count = 0;
            var listProduct = All.Where(i => i.Supplier.Contains(name));
            foreach (var m in listProduct)
            {
                count++;
            }
            return count;
        }

        //Thêm mới sản phẩm
        public SingleRsp AddProduct(Product product)
        {
            var singleRsp = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var c = context.Products.Add(product);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        singleRsp.SetError(e.Message);
                    }
                }
            }
            return singleRsp;
        }

        //Cập nhật sản phẩm
        public SingleRsp UpdateProduct(Product product)
        {
            var singleRsp = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var m = All.First(i => i.Id == product.Id);
                        m.Name = product.Name;
                        m.Supplier = product.Supplier;
                        m.Descriptions = product.Descriptions;
                        m.Images = product.Images;
                        m.Price = product.Price;
                        var c = context.Products.Update(m);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        singleRsp.SetError(e.Message);
                    }
                }
            }
            return singleRsp;
        }

        //Cập nhật giảm giá sản phẩm
        public SingleRsp UpdateProductOnSale(Product product)
        {
            var singleRsp = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var m = All.First(i => i.Id == product.Id);
                        if (m.OnSale == false)
                        {
                            m.OnSale = true;
                        }
                        else
                        {
                            m.OnSale = false;
                        }
                        var c = context.Products.Update(m);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        singleRsp.SetError(e.Message);
                    }
                }
            }
            return singleRsp;
        }

        //Xóa sản phẩm
        public int DeleteProduct(int id)
        {
            var singleRsp = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var m = All.First(i => i.Id == id);
                        var c = context.Products.Remove(m);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        singleRsp.SetError(e.Message);
                    }
                }
            }
            return id;
        }

        //Xóa các sản phẩm theo loại
        public int DeleteProductByCategory(int id)
        {
            var singleRsp = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var list = All.Where(i => i.CategoryId == id);
                        foreach (var m in list)
                        {
                            var c = context.Products.Remove(m);
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        singleRsp.SetError(e.Message);
                    }
                }
            }
            return id;
        }
    }
}
