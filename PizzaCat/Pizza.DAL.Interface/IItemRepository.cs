using System;
using System.Collections.Generic;
using Pizza.Domain.Response.Item;
using Pizza.Domain.Request.Item;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DAL.Interface
{
    public interface IItemRepository
    {
        Task<SaveItemRes> Save(SaveItemReq request);
        Task<ItemView> Get(int ItemId);
        Task<IEnumerable<ItemView>> GetItemBySectorsId(int SectorsId);
        Task<DeleteItemRes> Delete(int ItemId);
    }
}
