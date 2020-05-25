using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.ProduktService.Dto;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktDtoController : ControllerBase
    {
        private readonly IeShopService _eShopService;
        public ProduktDtoController(IeShopService eShopService)
        {
            _eShopService = eShopService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProduktDto>> GetProduktDtoById(int id)
        {
            var produktDto = await _eShopService.GetProduktDtoById(id);

            if (produktDto == null)
            {
                return NotFound();
            }

            return produktDto;
        }
    }
}