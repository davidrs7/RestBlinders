using System;
using System.Collections.Generic;
using System.Text;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.Entities;
using RestBlinders.Core.Interfases;
using RestBlinders.Core.QueryFillters;
using System.Threading.Tasks;
using RestBlinders.Core.Exceptions;

namespace RestBlinders.Core.Services
{
    public class inventarioService : IinvetarioService
    {

        public readonly IinventarioRepository _inventariosRepository;

        public inventarioService(IinventarioRepository inventarioRepository) {

            _inventariosRepository = inventarioRepository;
        }

        public async Task<bool> deleteInventario(int id)
        {
            return await _inventariosRepository.deleteInventario(id);
        }

        public inventarioDto getInventario(int id)
        {
            return  _inventariosRepository.GetInvInventario(id);
        }

        public async Task<IEnumerable<inventarioDto>> getInventarios(InventarioQueryFilters filters)
        { 
                return await _inventariosRepository.GetInvInventarios();            
        }

        public async Task postInventario(InvInventario inventario)
        {
              await _inventariosRepository.postInventario(inventario);
        }

        public async Task<bool> putInventario(InvInventario inventario)
        {
            return await _inventariosRepository.putInventario(inventario);
        }
    }
}
