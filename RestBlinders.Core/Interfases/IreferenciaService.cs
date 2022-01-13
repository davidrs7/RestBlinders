using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.QueryFillters;
using RestBlinders.Core.Entities;

namespace RestBlinders.Core.Interfases
{
    public interface IreferenciaService
    {
        Task<IEnumerable<InvReferencia>> getReferencias(ReferenciaQueryFilter filters);
        InvReferencia getReferencia(int id);
        Task postReferencia(InvReferencia referencia);
        Task<bool> deleteReferencia(int id);
        Task<bool> putReferencia(InvReferencia referencia);


    }
}
