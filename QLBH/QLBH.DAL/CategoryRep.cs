using QLBH.Common.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using QLBH.DAL.Models;
using System.Linq;
using QLBH.Common.Rsp;

namespace QLBH.DAL
{
    public class CategoryRep:GenericRep<qlbhContext, Category>
    {
        public CategoryRep()
        {

        }

        //Lấy loại sản phẩm bằng mã loại sản phẩm
        public override Category Read(int id)
        {
            var listCategory = All.FirstOrDefault(c => c.Id == id);
            return listCategory;
        }

        //Lấy danh sách tất cả các loại sản phẩm
        public SingleRsp GetAllCategory()
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = All;
            return singleRsp;
        }

        //Thêm mới loại sản phẩm
        public SingleRsp AddCategory(Category category)
        {
            var singleRsp = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var c = context.Categories.Add(category);
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

        //Cập nhật loại sản phẩm
        public SingleRsp UpdateCategory(Category category)
        {
            var singleRsp = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var m = All.First(i => i.Id == category.Id);
                        m.Name = category.Name;
                        var c = context.Categories.Update(m);
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

        //Xóa loại sản phẩm
        public int Remove(int id)
        {
            var singleRsp = new SingleRsp();
            using (var context = new qlbhContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var m = All.First(i => i.Id == id);
                        var c = context.Categories.Remove(m);
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
