using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.UnitPrice;
using Pizza.Domain.Request;
using System.Threading.Tasks;
using Pizza.BAL.Interface;
using Pizza.DAL.Interface;

namespace Pizza.BAL.Implement
{
    public class UnitPriceService : IUnitPriceService
    {
        private readonly IUnitPriceRepository unitPriceRepository;

        public UnitPriceService(IUnitPriceRepository unitPriceRepository)
        {
            this.unitPriceRepository = unitPriceRepository;
        }

        public async Task<IEnumerable<UnitPriceByItemIdView>> GetUnitPriceByItemId(int ItemId)
        {
            return await unitPriceRepository.GetUnitPriceByItemId(ItemId);
        }
    }
}
