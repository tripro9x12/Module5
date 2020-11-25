using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Pizza.DAL.Interface;
using Pizza.Domain.Request.UnitPrice;
using Pizza.Domain.Response.UnitPrice;
using System.Data;
namespace Pizza.DAL.Implement
{
    public class UnitPriceRepository : BaseReposetory, IUnitPriceRepository
    {
        public async Task<DeleteUnitPriceRes> Delete(int PriceId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PriceId", PriceId);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteUnitPriceRes>(cnn: connection,
                                                                                sql: "sp_DeleteUnitPriceById",
                                                                                param: parameters,
                                                                                commandType: CommandType.StoredProcedure
                                                                                );
        }

        public async Task<UnitPriceView> Get(int PriceId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PriceId", PriceId);
            return await SqlMapper.QueryFirstOrDefaultAsync<UnitPriceView>(cnn: connection,
                                                                                   sql: "sp_GetUniPriceById",
                                                                                   param: parameters,
                                                                                   commandType: CommandType.StoredProcedure
                                                                                   );
        }

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

        public async Task<IEnumerable<UnitPriceView>> GetUnitPriceBySizeId(int SizeId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SizeId", SizeId);
            return await SqlMapper.QueryAsync<UnitPriceView>(cnn: connection,
                                                            sql: "sp_GetUnitPriceBySizeId",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure
                                                            );
        }

        public async Task<SaveUnitPriceRes> Save(SaveUnitPriceReq request)
        {
            var result = new SaveUnitPriceRes()
            {
                PriceId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PriceId", request.PriceId);
                parameters.Add("@ItemId", request.ItemId);
                parameters.Add("@SizeId", request.SizeId);
                parameters.Add("@Price", request.Price);
                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveUnitPriceRes>(cnn: connection,
                                                                                    sql: "sp_SaveUnitPrice",
                                                                                    param: parameters,
                                                                                    commandType: CommandType.StoredProcedure
                                                                                    );
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
           

        }
    }
}
