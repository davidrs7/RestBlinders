using RestBlinders.Core.Entities;
using RestBlinders.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBlinders.Core.Interfases
{
    public interface IVendedorRepository
    {
        Task<IEnumerable<InvVendedore>> GetVendedores();
        InvVendedore GetVendedor(int id);
        Task<bool> deleteVendedor(int id);
        Task postVendedor(InvVendedore Vendedor);
        Task<bool> putVendedor(InvVendedore Vendedor);
    }
}
