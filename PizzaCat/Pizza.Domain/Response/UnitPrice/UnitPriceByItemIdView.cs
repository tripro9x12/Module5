using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Domain.Response.UnitPrice
{
    public class UnitPriceByItemIdView
    {
        public int PriceId { get; set; }
        public string SizeName { get; set; }
        public int Price { get; set; }
    }
}
