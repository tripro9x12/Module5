using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Pizza.DAL.Interface;
using Pizza.Domain.Request.Sectors;
using Pizza.Domain.Response.Sectors;
using System.Data;

namespace Pizza.DAL.Implement
{
    public class SectorsRepository : BaseReposetory, ISectorsRepository
    {
        public async Task<DeleteSectorsRes> Delete(int SectorsId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SectorsId", SectorsId);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteSectorsRes>(cnn: connection,
                                                                              sql: "sp_DeleteSectorsById",
                                                                              param: parameters,
                                                                              commandType: CommandType.StoredProcedure
                                                                              );
        }

        public async Task<SectorsView> Get(int SectorsId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SectorsId", SectorsId);
            return await SqlMapper.QueryFirstOrDefaultAsync<SectorsView>(cnn: connection,
                                                                        sql: "sp_GetSectorsById",
                                                                        param: parameters,
                                                                        commandType: CommandType.StoredProcedure
                                                                        );
        }

        public async Task<IEnumerable<SectorsView>> Gets()
        {
            return await SqlMapper.QueryAsync<SectorsView>(cnn: connection,
                                                           sql: "sp_GetSectors",
                                                           commandType: CommandType.StoredProcedure
                                                           );
        }

        public async Task<SaveSectorsRes> Save(SaveSectors request)
        {
            var result = new SaveSectorsRes()
            {
                SectorsId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SectorsId", request.SectorsId);
                parameters.Add("@SectorsName", request.SectorsName);
                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveSectorsRes>(cnn: connection,
                                                                                  sql: "sp_SaveSectors",
                                                                                  param: parameters,
                                                                                  commandType: CommandType.StoredProcedure
                                                                                  );
                return result;
            }
            catch(Exception e)
            {
                return result;
            }
        }
    }
}
