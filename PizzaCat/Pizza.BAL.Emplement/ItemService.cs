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

        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<SaveItemRes> Save(SaveItemReq request)
        {
            return await itemRepository.Save(request);
        }
    }
}
