using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.Sectors;
using Pizza.Domain.Request.Sectors;
using System.Threading.Tasks;
using Pizza.BAL.Interface;
using Pizza.DAL.Interface;

namespace Pizza.BAL.Implement
{
    public class SectorsService : ISectorsService
    {
        private readonly ISectorsRepository sectorsRepository;

        public SectorsService(ISectorsRepository sectorsRepository)
        {
            this.sectorsRepository = sectorsRepository;
        }

        public async Task<DeleteSectorsRes> Delete(int SectorsId)
        {
            return await sectorsRepository.Delete(SectorsId);
        }

        public async Task<SectorsView> Get(int SectorsId)
        {
            return await sectorsRepository.Get(SectorsId);
        }

        public async Task<IEnumerable<SectorsView>> Gets()
        {
            return await sectorsRepository.Gets();
        }

        public async Task<SaveSectorsRes> Save(SaveSectors request)
        {
            return await sectorsRepository.Save(request);
        }
    }
}
