using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Domain.Response.Item
{
    public class Items
    {
        public string SectorsName { get; set; }
        public List<ItemView> ListItems { get; set; }
    }
}
