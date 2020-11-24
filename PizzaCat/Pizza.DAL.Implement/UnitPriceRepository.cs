using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Pizza.DAL.Interface;
using Pizza.Domain.Request;
using Pizza.Domain.Response.UnitPrice;
using System.Data;
namespace Pizza.DAL.Implement
{
    public class UnitPriceRepository : BaseReposetory, IUnitPriceRepository
    {
        public async Task<IEnumerable<UnitPriceByItemIdView>> GetUnitPriceByItemId(int ItemId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ItemId", ItemId);
            return await SqlMapper.QueryAsync<UnitPriceByItemIdView>(cnn: connection,
                                                                                   sql: "sp_GetUnitPriceByItemId",
                                                                                   param: parameters,
                                                                                   commandType: CommandType.StoredProcedure
                                                                                   );
        }
    }
}
