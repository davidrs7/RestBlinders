using RestBlinders.Core.Entities;
using RestBlinders.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBlinders.Core.Interfases
{
    public interface IcolorRepository
    {
        Task<IEnumerable<InvColore>> GetColores();
        InvColore GetColor(int id);
        Task<bool> deleteColor(int id);
        Task postColor(InvColore Color);
        Task<bool> putColor(InvColore Color);
    }
}
