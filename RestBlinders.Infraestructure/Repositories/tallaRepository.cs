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
    public class TallaRepository : ItallaRepository
    {
        private readonly BusosBlindersContext _dbcontext;
        public TallaRepository(BusosBlindersContext BusosBlindersContext)
        {
            _dbcontext = BusosBlindersContext;
        }
        public async Task<bool> deleteTalla(int id)
        {
            try
            {
                var TallaDelete = GetTalla(id);
                _dbcontext.Remove(TallaDelete);
                int rows = await _dbcontext.SaveChangesAsync();
                return rows > 0;
            }
            catch (Exception Ex)
            {
                throw new ExceptionsBusiness("Error al eliminar un registro de la tabla Tallas ***" + Ex.Message + "***");
            }
        }

        public InvTalla GetTalla(int id)
        {
            try
            {
                var Talla = GetTallas().Result.FirstOrDefault(x => x.TallaCodigo == id);
                return Talla;
            }
            catch
            {
                throw new ExceptionsBusiness("Error al obtener una Talla por Id");
            }
        }

        public async Task<IEnumerable<InvTalla>> GetTallas()
        {
            try
            {
                var query = await _dbcontext.InvTallas.ToListAsync();
                return query;
            }
            catch
            {
                throw new ExceptionsBusiness("Error al obtener los Tallas");
            }
        }

        public async Task postTalla(InvTalla Talla)
        {
            try
            {
                Talla.UpdateAt = System.DateTime.Now;
                Talla.CreatedAt = System.DateTime.Now;
                _dbcontext.InvTallas.Add(Talla);
                await _dbcontext.SaveChangesAsync();
            }
            catch
            {
                throw new ExceptionsBusiness("Error al crear el registro en la tabla de Tallas");
            }
        }
        public async Task<bool> putTalla(InvTalla Talla)
        {
            try
            {
                var TallaUpdate = GetTalla(Talla.TallaCodigo);
                TallaUpdate.TallaDescripcion = Talla.TallaDescripcion;
                TallaUpdate.UpdateAt = System.DateTime.Now;
                TallaUpdate.CreatedAt = TallaUpdate.CreatedAt;
                _dbcontext.Update(TallaUpdate);
                int rows = await _dbcontext.SaveChangesAsync();
                return rows > 0;
            }
            catch (Exception Ex)
            {
                throw new ExceptionsBusiness("Error al actualizar un registro en las Tallas *** " + Ex.Message + "***");
            }
        }
    }
}
