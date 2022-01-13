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
    public class VendedoresController : ControllerBase
    {

        private readonly IVendedorService _VendedorService;
        private IMapper _mapper;

        public VendedoresController(IVendedorService VendedorService, IMapper mapper)
        {
            _VendedorService = VendedorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getVendedores([FromQuery] VendedorQueryFilter filters)
        {
            var Vendedores = await _VendedorService.getVendedores(filters);
            var response = new Response<IEnumerable<InvVendedore>>(Vendedores); 
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult getVendedor(int id)
        {
            var Vendedor = _VendedorService.getVendedor(id);
            var Response = new Response<InvVendedore>(Vendedor);
            return Ok(Response);
        }

        [HttpPost]
        public async Task<IActionResult> PostVendedor(InvVendedore Vendedor)
        {
            await _VendedorService.postVendedor(Vendedor);
            var Response = new Response<InvVendedore>(Vendedor);
            return Ok(Response);    
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedor(int id, InvVendedore Vendedor)
        {
            var VendedorMap = _mapper.Map<InvVendedore>(Vendedor);
            VendedorMap.VendedorCodigo = id;
            var Result = await _VendedorService.putVendedor(VendedorMap);
            var Response = new Response<bool>(Result);
            return Ok(Response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendedor(int id)
        {
            var result = await _VendedorService.deleteVendedor(id);
            var response = new Response<bool>(result);
            return Ok(response);        
        }

    }
}
