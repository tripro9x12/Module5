using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.Size;
using Pizza.Domain.Request.Size;
using System.Threading.Tasks;

namespace Pizza.BAL.Interface
{
    public interface ISizeService
    {
        Task<SaveSizeRes> Save(SaveSizeReq request);
        Task<DeleteSizeRes> Delete(int SizeId);
        Task<IEnumerable<SizeView>> Gets();
        Task<SizeView> Get(int SizeId);
    }
}
