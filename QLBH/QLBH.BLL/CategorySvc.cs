using QLBH.Common.BLL;
using QLBH.Common.Rsp;
using QLBH.Common.Req;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.BLL
{
    public class CategorySvc:GenericSvc<CategoryRep, Category>
    {
        private CategoryRep categoryRep;
        public CategorySvc()
        {
            categoryRep = new CategoryRep();
        }

        //Lấy loại sản phẩm bằng mã loại sản phẩm
        public override SingleRsp Read(int id)
        {
            var singleRes = new SingleRsp();
            singleRes.Data = _rep.Read(id);
            return singleRes;
        }

        //Lấy danh sách tất cả các loại sản phẩm
        public SingleRsp GetAllCategory()
        {
            var singleRsp = new SingleRsp();
            singleRsp = categoryRep.GetAllCategory();
            return singleRsp;
        }

        //Thêm mới loại sản phẩm
        public SingleRsp AddCategory(CategoryReq categoryReq)
        {
            var singleRsp = new SingleRsp();
            Category c = new Category();
            c.Name = categoryReq.Name;
            singleRsp = categoryRep.AddCategory(c);
            return singleRsp;
        }

        //Cập nhật loại sản phẩm
        public SingleRsp UpdateCategory(CategoryReq categoryReq)
        {
            var singleRsp = new SingleRsp();
            Category c = _rep.Read(categoryReq.Id);
            c.Name = categoryReq.Name;
            singleRsp = categoryRep.UpdateCategory(c);
            return singleRsp;
        }

        //Xóa loại sản phẩm theo mã loại sản phẩm
        public SingleRsp Remove(int id)
        {
            var singleRsp = new SingleRsp();
            singleRsp.Data = categoryRep.Remove(id);
            return singleRsp;
        }
    }
}
