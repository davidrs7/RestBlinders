using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestBlinders.Core.QueryFillters;
using RestBlinders.Core.Interfases;
using AutoMapper;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.Entities;
using RestBlinders.api.Response;
using RestBlinders.Core.Exceptions; 

namespace RestBlinders.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallasController : ControllerBase
    {

        private readonly ITallaService _TallaService;
        private IMapper _mapper;

        public TallasController(ITallaService TallaService, IMapper mapper)
        {
            _TallaService = TallaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getTallas([FromQuery] TallaQueryFilter filters)
        {
            var Tallas = await _TallaService.getTallas(filters);
            var response = new Response<IEnumerable<InvTalla>>(Tallas); 
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult getTalla(int id)
        {
            var Talla = _TallaService.getTalla(id);
            var Response = new Response<InvTalla>(Talla);
            return Ok(Response);
        }

        [HttpPost]
        public async Task<IActionResult> PostTalla(InvTalla Talla)
        {
            await _TallaService.postTalla(Talla);
            var Response = new Response<InvTalla>(Talla);
            return Ok(Response);    
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTalla(int id, InvTalla Talla)
        {
            var TallaMap = _mapper.Map<InvTalla>(Talla);
            TallaMap.TallaCodigo = id;
            var Result = await _TallaService.putTalla(TallaMap);
            var Response = new Response<bool>(Result);
            return Ok(Response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTalla(int id)
        {
            var result = await _TallaService.deleteTalla(id);
            var response = new Response<bool>(result);
            return Ok(response);        
        }

    }
}
