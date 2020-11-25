using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Domain.Response.UnitPrice
{
    public class UnitPriceView
    {
        public int PriceId { get; set; }
        public string ItemName { get; set; }
        public string SizeName { get; set; }
        public int Price { get; set; }
        public string Ingredient { get; set; }
        public int Discount { get; set; }
        public string ImageItem { get; set; }

    }
}
