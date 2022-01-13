using RestBlinders.Core.Entities;
using RestBlinders.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBlinders.Core.Interfases
{
    public interface ItallaRepository
    {
        Task<IEnumerable<InvTalla>> GetTallas();
        InvTalla GetTalla(int id);
        Task<bool> deleteTalla(int id);
        Task postTalla(InvTalla Talla);
        Task<bool> putTalla(InvTalla Talla);
    }
}
