using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Domain.Request.Size;
using Pizza.Domain.Response.Size;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.BAL.Interface;

namespace PizzaCat.API.Controllers
{
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService sizeService;

        public SizeController(ISizeService sizeService)
        {
            this.sizeService = sizeService;
        }

        [HttpPost, HttpPatch]
        [Route("api/size/save")]
        public async Task<OkObjectResult> SaveSize(SaveSizeReq request)
        {
            var result = await sizeService.Save(request);
            return Ok(result);
        }
        [HttpGet("api/size/gets")]
        public async Task<OkObjectResult> Gets()
        {
            var result = await sizeService.Gets();
            return Ok(result);
        }

        [HttpGet("api/size/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var result = await sizeService.Get(id);
            return Ok(result);
        }

        [HttpGet("api/size/delete/{id}")]
        public async Task<OkObjectResult> DeleteSectors(int id)
        {
            var delResult = await sizeService.Delete(id);
            return Ok(delResult);
        }

    }
}
