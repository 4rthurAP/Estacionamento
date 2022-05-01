using Estacionamento.Domain.Contracts.Base;
using Estacionamento.Domain.Enums;
using Estacionamento.Domain.Models.Bussiness;

namespace Estacionamento.Domain.Contracts.Services
{
    public interface IClientService : IService<Client>
    {
        Task<IEnumerable<Client>> GetByPlate(string plate);
        Task<IEnumerable<Client>> GetByStatus(Status status);
    }
}
