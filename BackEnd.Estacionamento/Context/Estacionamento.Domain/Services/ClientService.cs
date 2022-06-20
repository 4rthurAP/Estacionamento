using Estacionamento.Domain.Contracts.Base;
using Estacionamento.Domain.Contracts.Notificator;
using Estacionamento.Domain.Contracts.Services;
using Estacionamento.Domain.Enums;
using Estacionamento.Domain.Models.Bussiness;
using Estacionamento.Domain.Service.Base;
using Estacionamento.Domain.Validations;
using FluentValidation.Results;

namespace Estacionamento.Domain.Service
{
    public class ClientService : Service<Client>, IClientService
    {
        private readonly IRepository<Log> _logRepository;
        public ClientService(INotificator notificator, IRepository<Client> repository, IRepository<Log> logRepository) : base(notificator, repository)
        {
            _logRepository = logRepository;
        }

        public override async Task<Client> SaveAsync(Client entity)
        {
            throw new Exception("ERRO");
            if (!IsValid(new ClientValidation(), entity))
            {
                await _logRepository.SaveAsync(new Log() {Name = entity.Name, Car = entity.Car, Plate = entity.Plate});
                return await Task.FromResult<Client>(null);
            }
            await _logRepository.SaveAsync(new Log() { Name = entity.Name, Car = entity.Car, Plate = entity.Plate });

            return await base.SaveAsync(entity);
        }

        public override async Task<Client> UpdateAsync(Client entity)
        {
            if (!IsValid(new ClientValidation(), entity))
            {
                await _logRepository.SaveAsync(new Log() { Name = entity.Name, Car = entity.Car, Plate = entity.Plate });
                return await Task.FromResult<Client>(null);     
            }
            await _logRepository.SaveAsync(new Log() { Name = entity.Name, Car = entity.Car, Plate = entity.Plate });

            return await base.UpdateAsync(entity);
        }

        public async Task<IEnumerable<Client>> GetByPlate(string plate)
        {
            var clients = await _repository.GetByExpressionAsync(e => e.Plate.StartsWith(plate) || e.Plate == plate);

            if (!clients.Any())
                _notificador.Handle(new ValidationFailure(null, "Não Foi encontrado nenhum carro com essa placa!"));

            return clients;
        }

        public async Task<IEnumerable<Client>> GetByStatus(Status status) =>
            await _repository.GetByExpressionAsync(e => e.Status == status);
    }
}
