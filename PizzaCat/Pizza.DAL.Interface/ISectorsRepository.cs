using System;
using System.Collections.Generic;
using Pizza.Domain.Response.Sectors;
using Pizza.Domain.Request.Sectors;
using System.Text;
using System.Threading.Tasks;
namespace Pizza.DAL.Interface
{
    public interface ISectorsRepository
    {
        Task<SaveSectorsRes> Save(SaveSectors request);
        Task<DeleteSectorsRes> Delete(int SectorsId);
        Task<IEnumerable<SectorsView>> Gets();
        Task<SectorsView> Get(int SectorsId);
    }
}
