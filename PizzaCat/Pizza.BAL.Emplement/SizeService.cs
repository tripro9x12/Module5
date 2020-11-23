using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.Size;
using Pizza.Domain.Request.Size;
using System.Threading.Tasks;
using Pizza.BAL.Interface;
using Pizza.DAL.Interface;

namespace Pizza.BAL.Implement
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository sizeRepository;

        public SizeService(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public async Task<DeleteSizeRes> Delete(int SizeId)
        {
            return await sizeRepository.Delete(SizeId);
        }

        public async Task<SizeView> Get(int SizeId)
        {
            return await sizeRepository.Get(SizeId);
        }

        public async Task<IEnumerable<SizeView>> Gets()
        {
            return await sizeRepository.Gets();
        }

        public async Task<SaveSizeRes> Save(SaveSizeReq request)
        {
            return await sizeRepository.Save(request);
        }
    }
}
