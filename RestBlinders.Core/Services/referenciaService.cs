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
    public class referenciaService : IreferenciaService
    {
        public readonly IreferenciaRepository _referenciaRepository;

        public referenciaService(IreferenciaRepository referenciaRepository)
        {
            _referenciaRepository = referenciaRepository;
        }

        public Task<bool> deleteReferencia(int id)
        {
            return _referenciaRepository.deleteReferencia(id);
        }

        public InvReferencia getReferencia(int id)
        {
            return _referenciaRepository.GetReferencia(id);
        }
        public async Task<IEnumerable<InvReferencia>> getReferencias(ReferenciaQueryFilter filters)
        {
            return await _referenciaRepository.GetReferencias();
        }

        public Task postReferencia(InvReferencia referencia)
        {
            return _referenciaRepository.postReferencia(referencia);
        }

        public Task<bool> putReferencia(InvReferencia referencia)
        {
            return _referenciaRepository.putReferencia(referencia);
        }

    }
}
