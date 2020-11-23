using System;
using System.Collections.Generic;
using Pizza.Domain.Response.Size;
using Pizza.Domain.Request.Size;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DAL.Interface
{
    public interface ISizeRepository
    {
        Task<SaveSizeRes> Save(SaveSizeReq request);
        Task<DeleteSizeRes> Delete(int SizeId);
        Task<IEnumerable<SizeView>> Gets();
        Task<SizeView> Get(int SizeId);
    }
}
