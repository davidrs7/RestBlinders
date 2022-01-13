using System;
using System.Collections.Generic;
using System.Text;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.QueryFillters;
using RestBlinders.Core.Entities;
using System.Threading.Tasks;

namespace RestBlinders.Core.Interfases
{
    public interface IinvetarioService
    {
        Task<IEnumerable<inventarioDto>> getInventarios(InventarioQueryFilters filters);
        inventarioDto getInventario(int id);
        Task postInventario(InvInventario inventario);
        Task<bool> deleteInventario(int id);
        Task<bool> putInventario(InvInventario inventario);


    }
}
