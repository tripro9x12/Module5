using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Domain.Request.Item
{
    public class SaveItemReq
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Ingredient { get; set; }
        public int SectorsId { get; set; }
        public int Discount  { get; set; }
        public string ImageItem { get; set; }

    }
}
