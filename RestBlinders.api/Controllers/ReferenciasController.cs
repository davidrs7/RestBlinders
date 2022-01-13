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
    public class ReferenciasController : ControllerBase
    {

        private readonly IreferenciaService _ReferenciaService;
        private readonly IMapper _mapper;

        public ReferenciasController(IreferenciaService ReferenciaService, IMapper mapper)
        {
            _ReferenciaService = ReferenciaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getReferencias([FromQuery] ReferenciaQueryFilter filters)
        {
            var Referencia = await _ReferenciaService.getReferencias(filters);
            var referenciaDto = _mapper.Map<IEnumerable<InvReferencia>>(Referencia);
            var response = new Response<IEnumerable<InvReferencia>>(referenciaDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetReferencia(int id)
        {
            var Referencia = _ReferenciaService.getReferencia(id);
            var invnetarioDto = _mapper.Map<InvReferencia>(Referencia);
            var response = new Response<InvReferencia>(invnetarioDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostReferencia(InvReferencia ReferenciaDto)
        {
            var Referencia = _mapper.Map<InvReferencia>(ReferenciaDto);
            await _ReferenciaService.postReferencia(Referencia);
            var ReferenciaMap = _mapper.Map<InvReferencia>(Referencia);
            var response = new Response<InvReferencia>(ReferenciaMap);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferencia(int id, InvReferencia Referencia)
        {
            var ReferenciaMap = _mapper.Map<InvReferencia>(Referencia);
            ReferenciaMap.RefCodigo = id;
            var result = await _ReferenciaService.putReferencia(ReferenciaMap);
            var response = new Response<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferencia(int id)
        {
            var result = await _ReferenciaService.deleteReferencia(id);
            var response = new Response<bool>(result);
            return Ok(response);
        }


    }
}