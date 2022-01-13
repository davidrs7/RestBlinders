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
    public class ColoresController : ControllerBase
    {

        private readonly IColorService _colorService;
        private IMapper _mapper;

        public ColoresController(IColorService colorService, IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getColores([FromQuery] ColorQueryFilter filters)
        {
            var Colores = await _colorService.getColores(filters);
            var response = new Response<IEnumerable<InvColore>>(Colores); 
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult getColor(int id)
        {
            var Color = _colorService.getColor(id);
            var Response = new Response<InvColore>(Color);
            return Ok(Response);
        }

        [HttpPost]
        public async Task<IActionResult> PostColor(InvColore Color)
        {
            await _colorService.postColor(Color);
            var Response = new Response<InvColore>(Color);
            return Ok(Response);    
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, InvColore Color)
        {
            var ColorMap = _mapper.Map<InvColore>(Color);
            ColorMap.ColorCodigo = id;
            var Result = await _colorService.putColor(ColorMap);
            var Response = new Response<bool>(Result);
            return Ok(Response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            var result = await _colorService.deleteColor(id);
            var response = new Response<bool>(result);
            return Ok(response);        
        }

    }
}
