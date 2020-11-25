using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Domain.Request.Item;
using Pizza.Domain.Response.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.BAL.Interface;

namespace PizzaCat.API.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }
        [HttpPost, HttpPatch]
        [Route("api/item/save")]
        public async Task<OkObjectResult> SaveItem(SaveItemReq request)
        {
            var result = await itemService.Save(request);
            return Ok(result);
        }
        
        [HttpGet("api/item/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var result = await itemService.Get(id);
            return Ok(result);
        }

        [HttpGet("api/item/getitemsbysectorsid/{id}")]
        public async Task<OkObjectResult> GetItemsBySectorsId(int id)
        {
            var result = await itemService.GetItemBySectorsId(id);
            return Ok(result);
        }

        [HttpGet("api/item/delete/{id}")]
        public async Task<OkObjectResult> Delete(int id)
        {
            var result = await itemService.Delete(id);
            return Ok(result);
        }
    }
}
