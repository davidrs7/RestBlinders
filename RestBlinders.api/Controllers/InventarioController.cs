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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestBlinders.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {

        private readonly IinvetarioService _inventarioService;
        private readonly IMapper _mapper;

        public InventarioController(IinvetarioService inventarioService, IMapper mapper)
        {
            _inventarioService = inventarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getInventarios([FromQuery] InventarioQueryFilters filters)
        { 
                var inventario = await _inventarioService.getInventarios(filters);
                var invnetarioDto = _mapper.Map<IEnumerable<inventarioDto>>(inventario);
                var response = new Response<IEnumerable<inventarioDto>>(invnetarioDto);
                return Ok(response); 
        }

        [HttpGet("{id}")]
        public IActionResult GetInventario(int id)
        {
            var inventario =   _inventarioService.getInventario(id);
            var invnetarioDto =  _mapper.Map<inventarioDto>(inventario);
            var response = new Response<inventarioDto>(invnetarioDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostInventario(InvInventario InventarioDto)
        {
            var inventario = _mapper.Map<InvInventario>(InventarioDto);
            await _inventarioService.postInventario(inventario);
            var inventarioDto = _mapper.Map<InvInventario>(inventario);
            var response = new Response<InvInventario>(inventarioDto);
            return Ok(response); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario(int id, InvInventario Inventario) 
        {
            var inventario = _mapper.Map<InvInventario>(Inventario);
            var result = await _inventarioService.putInventario(inventario);
            var response = new Response<bool>(result); 
            return Ok(response); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            var result = await _inventarioService.deleteInventario(id);
            var response = new Response<bool>(result);
            return Ok(response);
        }


    }
}