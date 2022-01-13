using AutoMapper;
using RestBlinders.Core.DTOs;
using RestBlinders.Core.Entities;

namespace RestBlinders.Infraestructure.AutoMapper
{
  public class autoMapp : Profile
    {
        public autoMapp() {
            CreateMap<InvInventario, inventarioDto>();
        }
    }
}