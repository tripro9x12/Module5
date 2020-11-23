using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Domain.Request.Size
{
    public class SaveSizeReq
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
    }
}
