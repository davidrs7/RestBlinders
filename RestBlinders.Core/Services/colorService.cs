using System;
using System.Collections.Generic;
using System.Text;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.Entities;
using RestBlinders.Core.Interfases;
using RestBlinders.Core.QueryFillters;
using System.Threading.Tasks;
using RestBlinders.Core.Exceptions;

namespace RestBlinders.Core.Services
{
    public class colorService : IColorService
    {
        public readonly IcolorRepository _colorRepository;

        public colorService(IcolorRepository colorRepository)
        {
            _colorRepository = colorRepository;        
        }

        public Task<bool> deleteColor(int id)
        {
            return _colorRepository.deleteColor(id);
        }

        public InvColore getColor(int id)
        {
            return _colorRepository.GetColor(id);
        }

        public Task<IEnumerable<InvColore>> getColores(ColorQueryFilter filters)
        {
            return _colorRepository.GetColores();
        }

        public Task postColor(InvColore color)
        {
            return _colorRepository.postColor(color);
        }

        public Task<bool> putColor(InvColore color)
        {
            return _colorRepository.putColor(color);
        }
    }
}
