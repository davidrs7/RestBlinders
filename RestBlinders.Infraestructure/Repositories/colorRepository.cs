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
    public class colorRepository : IcolorRepository
    {
        private readonly BusosBlindersContext _dbcontext;
        public colorRepository(BusosBlindersContext BusosBlindersContext)
        {
            _dbcontext = BusosBlindersContext;
        }
        public async Task<bool> deleteColor(int id)
        {
            try
            {
                var ColorDelete = GetColor(id);
                _dbcontext.Remove(ColorDelete);
                int rows = await _dbcontext.SaveChangesAsync();
                return rows > 0;
            }
            catch (Exception Ex)
            {
                throw new ExceptionsBusiness("Error al eliminar un registro de la tabla Colores ***" + Ex.Message + "***");
            }
        }

        public InvColore GetColor(int id)
        {
            try
            {
                var Color = GetColores().Result.FirstOrDefault(x => x.ColorCodigo == id);
                return Color;
            }
            catch
            {
                throw new ExceptionsBusiness("Error al obtener una Color por Id");
            }
        }

        public async Task<IEnumerable<InvColore>> GetColores()
        {
            try
            {
                var query = await _dbcontext.InvColores.ToListAsync();
                return query;
            }
            catch
            {
                throw new ExceptionsBusiness("Error al obtener los Colores");
            }
        }

        public async Task postColor(InvColore Color)
        {
            try
            {
                Color.UpdateAt = System.DateTime.Now;
                Color.CreatedAt = System.DateTime.Now;
                _dbcontext.InvColores.Add(Color);
                await _dbcontext.SaveChangesAsync();
            }
            catch
            {
                throw new ExceptionsBusiness("Error al crear el registro en la tabla de Colors");
            }
        }
        public async Task<bool> putColor(InvColore Color)
        {
            try
            {
                var ColorUpdate = GetColor(Color.ColorCodigo);
                ColorUpdate.ColorDescripcion = Color.ColorDescripcion;
                ColorUpdate.UpdateAt = System.DateTime.Now;
                ColorUpdate.CreatedAt = ColorUpdate.CreatedAt;
                _dbcontext.Update(ColorUpdate);
                int rows = await _dbcontext.SaveChangesAsync();
                return rows > 0;
            }
            catch (Exception Ex)
            {
                throw new ExceptionsBusiness("Error al actualizar un registro en las Colors *** " + Ex.Message + "***");
            }
        }
    }
}
