using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.Common.Req
{
    public class CommentReq
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public short? Star { get; set; }
    }
}
