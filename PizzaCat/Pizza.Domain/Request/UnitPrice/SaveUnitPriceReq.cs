using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Domain.Request.UnitPrice
{
    public class SaveUnitPriceReq
    {
        public int PriceId { get; set; }
        public int ItemId { get; set; }
        public int SizeId { get; set; }
        public int Price { get; set; }
    }
}
