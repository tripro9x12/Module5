using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Domain.Request.UnitPrice;
using Pizza.Domain.Response.UnitPrice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.BAL.Interface;

namespace PizzaCat.API.Controllers
{
    [ApiController]
    public class UnitPriceController : ControllerBase
    {
        private readonly IUnitPriceService unitPriceService;

        public UnitPriceController(IUnitPriceService unitPriceService)
        {
            this.unitPriceService = unitPriceService;
        }

        [HttpGet("api/unitprice/getunitpricebyitemid/{id}")]
        public async Task<OkObjectResult> GetUnitPriceByItemId(int id)
        {
            var result = await unitPriceService.GetUnitPriceByItemId(id);
            return Ok(result);
        }

        [HttpPost,HttpPatch]
        [Route("api/unitprice/save")]
        public async Task<OkObjectResult> Save(SaveUnitPriceReq request)
        {
            var result = await unitPriceService.Save(request);
            return Ok(result);
        }

        [HttpGet("api/unitprice/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var result = await unitPriceService.Get(id);
            return Ok(result);
        }

        [HttpGet("api/unitprice/getunitpricebysizeid/{id}")]
        public async Task<OkObjectResult> GetUnitPriceBySizeId(int id)
        {
            var result = await unitPriceService.GetUnitPriceBySizeId(id);
            return Ok(result);
        }

        [HttpGet("api/unitprice/delete/{id}")]
        public async Task<OkObjectResult> Delete(int id)
        {
            var delResult = await unitPriceService.Delete(id);
            return Ok(delResult);
        }
    }
}
