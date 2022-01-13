using Microsoft.EntityFrameworkCore;
using RestBlinders.Core.Entities;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.Interfases;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestBlinders.Infraestructure.Data;
using System.Linq;
using RestBlinders.Core.Exceptions;
using System;

namespace RestBlinders.Infraestructure.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly BusosBlindersContext _dbcontext;
        public VendedorRepository(BusosBlindersContext BusosBlindersContext)
        {
            _dbcontext = BusosBlindersContext;
        }
        public async Task<bool> deleteVendedor(int id)
        {
            try
            {
                var VendedorDelete = GetVendedor(id);
                _dbcontext.Remove(VendedorDelete);
                int rows = await _dbcontext.SaveChangesAsync();
                return rows > 0;
            }
            catch (Exception Ex)
            {
                throw new ExceptionsBusiness("Error al eliminar un registro de la tabla Vendedores ***" + Ex.Message + "***");
            }
        }

        public InvVendedore GetVendedor(int id)
        {
            try
            {
                var Vendedor = GetVendedores().Result.FirstOrDefault(x => x.VendedorCodigo == id);
                return Vendedor;
            }
            catch
            {
                throw new ExceptionsBusiness("Error al obtener una Vendedor por Id");
            }
        }

        public async Task<IEnumerable<InvVendedore>> GetVendedores()
        {
            try
            {
                var query = await _dbcontext.InvVendedores.ToListAsync();
                return query;
            }
            catch
            {
                throw new ExceptionsBusiness("Error al obtener los Vendedores");
            }
        }

        public async Task postVendedor(InvVendedore Vendedor)
        {
            try
            {
                Vendedor.UpdateAt = System.DateTime.Now;
                Vendedor.CreatedAt = System.DateTime.Now;
                _dbcontext.InvVendedores.Add(Vendedor);
                await _dbcontext.SaveChangesAsync();
            }
            catch
            {
                throw new ExceptionsBusiness("Error al crear el registro en la tabla de Vendedors");
            }
        }
        public async Task<bool> putVendedor(InvVendedore Vendedor)
        {
            try
            {
                var VendedorUpdate = GetVendedor(Vendedor.VendedorCodigo);
                VendedorUpdate.VendedorApellidos = Vendedor.VendedorApellidos;
                VendedorUpdate.VendedorNombres = VendedorUpdate.VendedorNombres;
                VendedorUpdate.VendedorTelefono = Vendedor.VendedorTelefono;
                VendedorUpdate.VendedorTipiden = Vendedor.VendedorTipiden;
                VendedorUpdate.VendedorDireccion = Vendedor.VendedorDireccion;
                VendedorUpdate.VendedorIdentificacion = Vendedor.VendedorIdentificacion;
                VendedorUpdate.VendedorActivo = Vendedor.VendedorActivo;
                VendedorUpdate.UpdateAt = System.DateTime.Now;
                VendedorUpdate.CreatedAt = VendedorUpdate.CreatedAt;
                _dbcontext.Update(VendedorUpdate);
                int rows = await _dbcontext.SaveChangesAsync();
                return rows > 0;
            }
            catch (Exception Ex)
            {
                throw new ExceptionsBusiness("Error al actualizar un registro en las Vendedors *** " + Ex.Message + "***");
            }
        }
    }
}
