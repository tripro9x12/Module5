using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.Item;
using Pizza.Domain.Request.Item;
using System.Threading.Tasks;

namespace Pizza.BAL.Interface
{
    public interface IItemService
    {
        Task<SaveItemRes> Save(SaveItemReq request);
    }
}
