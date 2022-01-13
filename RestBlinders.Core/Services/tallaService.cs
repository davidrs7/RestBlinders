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
    public class TallaService : ITallaService
    {
        public readonly ItallaRepository _TallaRepository;

        public TallaService(ItallaRepository TallaRepository)
        {
            _TallaRepository = TallaRepository;        
        }

        public Task<bool> deleteTalla(int id)
        {
            return _TallaRepository.deleteTalla(id);
        }

        public InvTalla getTalla(int id)
        {
            return _TallaRepository.GetTalla(id);
        }

        public Task<IEnumerable<InvTalla>> getTallas(TallaQueryFilter filters)
        {
            return _TallaRepository.GetTallas();
        }

        public Task postTalla(InvTalla Talla)
        {
            return _TallaRepository.postTalla(Talla);
        }

        public Task<bool> putTalla(InvTalla Talla)
        {
            return _TallaRepository.putTalla(Talla);
        }
    }
}
