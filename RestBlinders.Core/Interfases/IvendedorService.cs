using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.QueryFillters;
using RestBlinders.Core.Entities;

namespace RestBlinders.Core.Interfases
{
    public interface IVendedorService
    {
        Task<IEnumerable<InvVendedore>> getVendedores(VendedorQueryFilter filters);
        InvVendedore getVendedor(int id);
        Task postVendedor(InvVendedore referencia);
        Task<bool> deleteVendedor(int id);
        Task<bool> putVendedor(InvVendedore referencia); 

    }
}
