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
    public class VendedorService : IVendedorService
    {
        public readonly IVendedorRepository _VendedorRepository;

        public VendedorService(IVendedorRepository VendedorRepository)
        {
            _VendedorRepository = VendedorRepository;        
        }

        public Task<bool> deleteVendedor(int id)
        {
            return _VendedorRepository.deleteVendedor(id);
        }

        public InvVendedore getVendedor(int id)
        {
            return _VendedorRepository.GetVendedor(id);
        }

        public Task<IEnumerable<InvVendedore>> getVendedores(VendedorQueryFilter filters)
        {
            return _VendedorRepository.GetVendedores();
        }

        public Task postVendedor(InvVendedore Vendedor)
        {
            return _VendedorRepository.postVendedor(Vendedor);
        }

        public Task<bool> putVendedor(InvVendedore Vendedor)
        {
            return _VendedorRepository.putVendedor(Vendedor);
        }
    }
}
