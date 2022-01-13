using Microsoft.EntityFrameworkCore;
using RestBlinders.Core.Entities;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.Interfases;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestBlinders.Infraestructure.Data;
using System.Linq;
using RestBlinders.Core.Exceptions;

namespace RestBlinders.Infraestructure.Repositories
{
    public class inventarioRepository : IinventarioRepository
    {
        private readonly BusosBlindersContext _dbcontext;

        public inventarioRepository(BusosBlindersContext BusosBlindersContext)
        {
            _dbcontext = BusosBlindersContext;
        }

        public async Task<bool> deleteInventario(int id)
        {

            try {
                var inventarioDelete = GetInvInventario(id);
                InvInventario inventario = new InvInventario
                {
                    RefCodigo = inventarioDelete.refCodigo,
                    InventarioCodigo = inventarioDelete.InventarioCodigo,
                    ColorCodigo = inventarioDelete.colorCodigo,
                    Cantidad = inventarioDelete.cantidad,
                    TallaCodigo = inventarioDelete.tallaCodigo
                };
                _dbcontext.Remove(inventario);
                int rows = await _dbcontext.SaveChangesAsync();
                return rows > 0;
            }
            catch {
                throw new ExceptionsBusiness("Error al eliminar uno de los registros del inventario");
            }
        }

        public inventarioDto GetInvInventario(int id)
        {
            try {
                var inventario = GetInvInventarios().Result.FirstOrDefault(x => x.InventarioCodigo == id);
                return inventario;
            }
            catch{
                throw new ExceptionsBusiness("Error al consumir GetInvInventario");
            }
        }

        public async Task<IEnumerable<inventarioDto>> GetInvInventarios()
        { 
            try {
                var query2 = (from inventario in _dbcontext.InvInventarios
                              join color in _dbcontext.InvColores on inventario.ColorCodigo equals color.ColorCodigo
                              join referencia in _dbcontext.InvReferencias on inventario.RefCodigo equals referencia.RefCodigo
                              join talla in _dbcontext.InvTallas on inventario.TallaCodigo equals talla.TallaCodigo
                              select new inventarioDto
                              {
                                  InventarioCodigo = inventario.InventarioCodigo,
                                  refCodigo = inventario.RefCodigo,
                                  refDesc = referencia.RefDescripcion,
                                  tallaCodigo = inventario.TallaCodigo,
                                  tallaDesc = talla.TallaDescripcion,
                                  colorCodigo = inventario.ColorCodigo,
                                  colorDesc = color.ColorDescripcion,
                                  cantidad = (int)inventario.Cantidad,
                                  createdAt = (System.DateTime)inventario.CreatedAt,
                                  updateAt = (System.DateTime)inventario.UpdateAt,

                              }).ToListAsync();
            

                return await query2;
            }
            catch  {
                throw new ExceptionsBusiness("Error al consultar todos los productos");
            } 
        }

        public async Task postInventario(InvInventario inventario)
        {
            try {
                inventario.CreatedAt = System.DateTime.Now;
                inventario.UpdateAt = System.DateTime.Now;
                _dbcontext.InvInventarios.Add(inventario);
                await _dbcontext.SaveChangesAsync();
            }
            catch
            {
                throw new ExceptionsBusiness("Error al insertar un registro en el inventario");
            }            
        }
        public async Task<bool> putInventario(InvInventario inventario)
        { 
            try
            {
                var inventarioUpdate = GetInvInventario(inventario.InventarioCodigo);
                InvInventario inventarioUp = new InvInventario
                {
                    RefCodigo = inventario.RefCodigo,
                    InventarioCodigo = inventario.InventarioCodigo,
                    ColorCodigo = inventario.ColorCodigo,
                    Cantidad = inventario.Cantidad,
                    TallaCodigo = inventario.TallaCodigo,
                    UpdateAt = System.DateTime.Now,
                    CreatedAt = inventarioUpdate.createdAt
                };
                _dbcontext.Update(inventarioUp);
                int rows = await _dbcontext.SaveChangesAsync();
                return rows > 0;
            }
            catch {
                throw new ExceptionsBusiness("Error al actualizar uno de los registros del inventario");
            }          
        }
    }
}
