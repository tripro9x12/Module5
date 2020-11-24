using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.UnitPrice;

namespace Pizza.Domain.Response.Item
{
    public class ItemView
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Ingredient { get; set; }
        public string SectorsName { get; set; }
        public int Discount { get; set; }
        public string ImageItem { get; set; }
        public List<UnitPriceByItemIdView> UnitPrices { get; set; }
    }
}
