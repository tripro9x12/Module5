using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.Sectors;
using Pizza.Domain.Request.Sectors;
using System.Threading.Tasks;
using Pizza.BAL.Interface;
using Pizza.DAL.Interface;
using Pizza.Domain.Response.Item;
using Pizza.Domain.Request.Item;

namespace Pizza.BAL.Implement
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;
        private readonly IUnitPriceRepository unitPriceRepository;
        private readonly ISectorsRepository sectorsRepository;

        public ItemService(IItemRepository itemRepository,
                           IUnitPriceRepository unitPriceRepository,
                           ISectorsRepository sectorsRepository)
        {
            this.itemRepository = itemRepository;
            this.unitPriceRepository = unitPriceRepository;
            this.sectorsRepository = sectorsRepository;
        }

        public async Task<DeleteItemRes> Delete(int ItemId)
        {
            return await itemRepository.Delete(ItemId);
        }

        public async Task<ItemView> Get(int ItemId)
        {
            var item = await itemRepository.Get(ItemId);
            item.UnitPrices = await unitPriceRepository.GetUnitPriceByItemId(item.ItemId);
            return item;
        }

        public async Task<Items> GetItemBySectorsId(int SectorsId)
        {
            var items = new Items();
            items.ListItems = await itemRepository.GetItemBySectorsId(SectorsId);
            foreach(var item in items.ListItems)
            {
                item.UnitPrices = await unitPriceRepository.GetUnitPriceByItemId(item.ItemId);
            }
            var sectors = await sectorsRepository.Get(SectorsId);
            items.SectorsName = sectors.SectorsName;
            return items;
        }

        public async Task<SaveItemRes> Save(SaveItemReq request)
        {
            return await itemRepository.Save(request);
        }
    }
}
