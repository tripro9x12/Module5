using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Pizza.DAL.Interface;
using Pizza.Domain.Request.Size;
using Pizza.Domain.Response.Size;
using System.Data;
namespace Pizza.DAL.Implement
{
    public class SizeRepositoty : BaseReposetory, ISizeRepository
    {
        public async Task<DeleteSizeRes> Delete(int SizeId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SizeId", SizeId);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteSizeRes>(cnn: connection,
                                                                              sql: "sp_DeleteSizeById",
                                                                              param: parameters,
                                                                              commandType: CommandType.StoredProcedure
                                                                              );
        }

        public async Task<SizeView> Get(int SizeId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SizeId", SizeId);
            return await SqlMapper.QueryFirstOrDefaultAsync<SizeView>(cnn: connection,
                                                                        sql: "sp_GetSizeById",
                                                                        param: parameters,
                                                                        commandType: CommandType.StoredProcedure
                                                                        );
        }

        public async Task<IEnumerable<SizeView>> Gets()
        {
            return await SqlMapper.QueryAsync<SizeView>(cnn: connection,
                                                           sql: "sp_GetSize",
                                                           commandType: CommandType.StoredProcedure
                                                           );
        }

        public async Task<SaveSizeRes> Save(SaveSizeReq request)
        {
            var result = new SaveSizeRes()
            {
                SizeId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SizeId", request.SizeId);
                parameters.Add("@SizeName", request.SizeName);
                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveSizeRes>(cnn: connection,
                                                                                  sql: "sp_SaveSize",
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
