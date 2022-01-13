using RestBlinders.Core.Entities;
using RestBlinders.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBlinders.Core.Interfases
{
    public interface IinventarioRepository
    {
        Task<IEnumerable<inventarioDto>> GetInvInventarios();
        inventarioDto GetInvInventario(int id);
        Task<bool> deleteInventario(int id);
        Task postInventario(InvInventario inventario);
        Task<bool> putInventario(InvInventario inventario);
    }
}
