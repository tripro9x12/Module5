using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Domain.Request.Sectors;
using Pizza.Domain.Response.Sectors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.BAL.Interface;

namespace PizzaCat.API.Controllers
{
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly ISectorsService sectorsService;

        public SectorsController(ISectorsService sectorsService)
        {
            this.sectorsService = sectorsService;
        }

        [HttpPost, HttpPatch]
        [Route("api/sectors/save")]
        public async Task<OkObjectResult> SaveSectors(SaveSectors request)
        {
            var result = await sectorsService.Save(request);
            return Ok(result);
        }
        [HttpGet("api/sectors/gets")]
        public async Task<OkObjectResult> Gets()
        {
            var result = await sectorsService.Gets();
            return Ok(result);
        }

        [HttpGet("api/sectors/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var result = await sectorsService.Get(id);
            return Ok(result);
        }

        [HttpGet("api/sectors/delete/{id}")]
        public async Task<OkObjectResult> DeleteSectors(int id)
        {
            var delResult = await sectorsService.Delete(id);
            return Ok(delResult);
        }

    }
}
