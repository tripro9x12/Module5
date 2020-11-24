using System;
using System.Collections.Generic;
using Pizza.Domain.Response.UnitPrice;
using Pizza.Domain.Request;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DAL.Interface
{
    public interface IUnitPriceRepository
    {
        Task<IEnumerable<UnitPriceByItemIdView>> GetUnitPriceByItemId(int ItemId);
    }
}
