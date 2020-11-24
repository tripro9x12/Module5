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
        [HttpPost, HttpPost]
        [Route("api/item/save")]
        public async Task<OkObjectResult> SaveItem(SaveItemReq request)
        {
            var result = await itemService.Save(request);
            return Ok(result);
        }
    }
}
