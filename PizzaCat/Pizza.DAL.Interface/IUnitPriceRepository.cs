using System;
using System.Collections.Generic;
using Pizza.Domain.Response.UnitPrice;
using Pizza.Domain.Request.UnitPrice;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DAL.Interface
{
    public interface IUnitPriceRepository
    {
        Task<IEnumerable<UnitPriceByItemIdView>> GetUnitPriceByItemId(int ItemId);
        Task<SaveUnitPriceRes> Save(SaveUnitPriceReq request);
        Task<DeleteUnitPriceRes> Delete(int PriceId);
        Task<UnitPriceView> Get(int PriceId);
        Task<IEnumerable<UnitPriceView>> GetUnitPriceBySizeId(int SizeId);
    }
}
