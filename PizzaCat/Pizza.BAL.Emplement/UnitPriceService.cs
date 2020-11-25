using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.UnitPrice;
using Pizza.Domain.Request.UnitPrice;
using System.Threading.Tasks;
using Pizza.BAL.Interface;
using Pizza.DAL.Interface;

namespace Pizza.BAL.Implement
{
    public class UnitPriceService : IUnitPriceService
    {
        private readonly IUnitPriceRepository unitPriceRepository;
        private readonly ISizeRepository sizeRepository;

        public UnitPriceService(IUnitPriceRepository unitPriceRepository,
                                ISizeRepository sizeRepository)
        {
            this.unitPriceRepository = unitPriceRepository;
            this.sizeRepository = sizeRepository;
        }

        public async Task<DeleteUnitPriceRes> Delete(int PriceId)
        {
            return await unitPriceRepository.Delete(PriceId);
        }

        public async Task<UnitPriceView> Get(int PriceId)
        {
            return await unitPriceRepository.Get(PriceId);
        }

        public async Task<IEnumerable<UnitPriceByItemIdView>> GetUnitPriceByItemId(int ItemId)
        {
            return await unitPriceRepository.GetUnitPriceByItemId(ItemId);
        }

        public async Task<UnitPrices> GetUnitPriceBySizeId(int SizeId)
        {
            var model = new UnitPrices();
            model.UnitPriceBySize = await unitPriceRepository.GetUnitPriceBySizeId(SizeId);
            var size = await sizeRepository.Get(SizeId);
            model.SizeName = size.SizeName;
            return model;
        }

        public async Task<SaveUnitPriceRes> Save(SaveUnitPriceReq request)
        {
            return await unitPriceRepository.Save(request);
        }
    }
}
