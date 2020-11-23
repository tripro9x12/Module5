using System;
using System.Collections.Generic;
using System.Text;
using Pizza.Domain.Response.Sectors;
using Pizza.Domain.Request.Sectors;
using System.Threading.Tasks;
namespace Pizza.BAL.Interface
{
    public interface ISectorsService
    {
        Task<SaveSectorsRes> Save(SaveSectors request);
        Task<DeleteSectorsRes> Delete(int SectorsId);
        Task<IEnumerable<SectorsView>> Gets();
        Task<SectorsView> Get(int SectorsId);
    }
}
