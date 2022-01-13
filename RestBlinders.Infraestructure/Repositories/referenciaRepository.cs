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
    public class referenciaRepository : IreferenciaRepository
    {
        private readonly BusosBlindersContext _dbcontext;
        public referenciaRepository(BusosBlindersContext BusosBlindersContext)
        {
            _dbcontext = BusosBlindersContext;
        }
        public async Task<bool> deleteReferencia(int id)
        {
            try
            { 
                var referenciaDelete = GetReferencia(id); 
                _dbcontext.Remove(referenciaDelete);
                int rows = await _dbcontext.SaveChangesAsync(); 
                return rows > 0;
            }
            catch (Exception Ex)
            {
                throw new ExceptionsBusiness("Error al eliminar un registro de la tabla referencias ***" + Ex.Message + "***");
            }
        }

        public InvReferencia GetReferencia(int id)
        {
            try
            {
                var referencia = GetReferencias().Result.FirstOrDefault(x => x.RefCodigo == id);
                return referencia;
            }
            catch
            {
                throw new ExceptionsBusiness("Error al obtener una referencia por Id");
            }
        }

        public async Task<IEnumerable<InvReferencia>> GetReferencias()
        {
            try
            {
                var query = await _dbcontext.InvReferencias.ToListAsync();
                return query;
            }
            catch
            {
                throw new ExceptionsBusiness("Error al obtener las referencias");
            }
        }

        public async Task postReferencia(InvReferencia referencia)
        {
            try
            {
                referencia.UpdateAt = System.DateTime.Now;
                referencia.CreatedAt = System.DateTime.Now;
                _dbcontext.InvReferencias.Add(referencia);
                await _dbcontext.SaveChangesAsync();
            }
            catch
            {
                throw new ExceptionsBusiness("Error al crear el registro en la tabla de referencias");
            }
        } 
        public async Task<bool> putReferencia(InvReferencia referencia)
        {
            try 
            {
                var referenciaUpdate = GetReferencia(referencia.RefCodigo);
                referenciaUpdate.RefDescripcion = referencia.RefDescripcion;
                referenciaUpdate.UpdateAt = System.DateTime.Now;
                referenciaUpdate.CreatedAt = referenciaUpdate.CreatedAt;
                _dbcontext.Update(referenciaUpdate);
                int rows = await _dbcontext.SaveChangesAsync();
                return rows > 0;
            }
            catch(Exception Ex)
            {
                throw new ExceptionsBusiness("Error al actualizar un registro en las referencias *** " + Ex.Message + "***");
            } 
        }
    }
}
