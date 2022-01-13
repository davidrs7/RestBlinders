using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.Entities;

namespace RestBlinders.Core.Interfases
{
    public interface IreferenciaRepository
    {
        Task<IEnumerable<InvReferencia>> GetReferencias();
        InvReferencia GetReferencia(int id);
        Task<bool> deleteReferencia(int id);
        Task postReferencia(InvReferencia referencia);
        Task<bool> putReferencia(InvReferencia referencia); 

    }
}
