using AutoMapper;
using Estacionamento.CrossCutting.Dto;
using Estacionamento.CrossCutting.ViewModel;
using Estacionamento.Domain.Models.Bussiness;

namespace Estacionamento.CrossCutting.Mapper
{
    public class ClientMapper : Profile
    {
        public ClientMapper()
        {
            CreateMap<ClientViewModel, Client>();
            CreateMap<Client, ClientDto>();
        }
    }
}
