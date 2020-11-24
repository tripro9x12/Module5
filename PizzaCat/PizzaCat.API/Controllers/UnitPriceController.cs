using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Domain.Request;
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
    }
}
