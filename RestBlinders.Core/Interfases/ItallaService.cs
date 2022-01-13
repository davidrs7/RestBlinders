using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.QueryFillters;
using RestBlinders.Core.Entities;

namespace RestBlinders.Core.Interfases
{
    public interface ITallaService
    {
        Task<IEnumerable<InvTalla>> getTallas(TallaQueryFilter filters);
        InvTalla getTalla(int id);
        Task postTalla(InvTalla referencia);
        Task<bool> deleteTalla(int id);
        Task<bool> putTalla(InvTalla referencia); 

    }
}
