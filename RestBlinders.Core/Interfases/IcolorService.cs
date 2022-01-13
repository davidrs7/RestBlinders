using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.QueryFillters;
using RestBlinders.Core.Entities;

namespace RestBlinders.Core.Interfases
{
    public interface IColorService
    {
        Task<IEnumerable<InvColore>> getColores(ColorQueryFilter filters);
        InvColore getColor(int id);
        Task postColor(InvColore referencia);
        Task<bool> deleteColor(int id);
        Task<bool> putColor(InvColore referencia); 

    }
}
