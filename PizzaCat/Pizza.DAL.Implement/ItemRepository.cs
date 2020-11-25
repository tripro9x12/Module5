using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Pizza.DAL.Interface;
using Pizza.Domain.Request.Item;
using Pizza.Domain.Response.Item;
using System.Data;

namespace Pizza.DAL.Implement
{
    public class ItemRepository : BaseReposetory, IItemRepository
    {
        public async Task<DeleteItemRes> Delete(int ItemId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ItemId", ItemId);
            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteItemRes>(cnn: connection,
                                                                            sql: "sp_DeleteItemById",
                                                                            param: parameters,
                                                                            commandType: CommandType.StoredProcedure
                                                                            );
        }

        public async Task<ItemView> Get(int ItemId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"ItemId", ItemId);
            return await SqlMapper.QueryFirstOrDefaultAsync<ItemView>(cnn: connection,
                                                                      sql: "sp_GetItemById",
                                                                      param: parameters,
                                                                      commandType: CommandType.StoredProcedure
                                                                      );
        }

        public async Task<IEnumerable<ItemView>> GetItemBySectorsId(int SectorsId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SectorsId", SectorsId);
            return await SqlMapper.QueryAsync<ItemView>(cnn: connection,
                                                        sql: "sp_GetItemBySectorsId",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure
                                                        );
        }

        public async Task<SaveItemRes> Save(SaveItemReq request)
        {
            var result = new SaveItemRes()
            {
                ItemId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ItemId", request.ItemId);
                parameters.Add("@ItemName", request.ItemName);
                parameters.Add("@SectorsId",request.SectorsId);
                parameters.Add("@Ingredient",request.Ingredient);
                parameters.Add("@Discount",request.Discount);
                parameters.Add("@ImageItem", request.ImageItem);
                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveItemRes>(cnn: connection,
                                                                                  sql: "sp_SaveItem",
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
