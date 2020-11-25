using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Domain.Response.UnitPrice
{
    public class UnitPrices
    {
        public string SizeName { get; set; }
        public IEnumerable<UnitPriceView> UnitPriceBySize { get; set; }
    }
}
