using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.Common.Req
{
    public class PutCommentReq
    {
        public string Content { get; set; }
        public short? Star { get; set; }
    }
}
