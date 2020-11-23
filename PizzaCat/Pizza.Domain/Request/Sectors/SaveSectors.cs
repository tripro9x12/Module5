using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Domain.Request.Sectors
{
    public class SaveSectors
    {
        public int SectorsId { get; set; }
        public string SectorsName { get; set; }
    }
}
