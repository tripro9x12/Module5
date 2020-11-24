using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.UnitPrice;
using Pizza.Domain.Request;
using System.Threading.Tasks;

namespace Pizza.BAL.Interface
{
    public interface IUnitPriceService
    {
        Task<IEnumerable<UnitPriceByItemIdView>> GetUnitPriceByItemId(int ItemId);
    }
}
