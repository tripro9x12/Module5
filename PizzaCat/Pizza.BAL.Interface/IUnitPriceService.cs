using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.UnitPrice;
using Pizza.Domain.Request.UnitPrice;
using System.Threading.Tasks;

namespace Pizza.BAL.Interface
{
    public interface IUnitPriceService
    {
        Task<IEnumerable<UnitPriceByItemIdView>> GetUnitPriceByItemId(int ItemId);
        Task<SaveUnitPriceRes> Save(SaveUnitPriceReq request);
        Task<DeleteUnitPriceRes> Delete(int PriceId);
        Task<UnitPriceView> Get(int PriceId);
        Task<UnitPrices> GetUnitPriceBySizeId(int SizeId);
    }
}
