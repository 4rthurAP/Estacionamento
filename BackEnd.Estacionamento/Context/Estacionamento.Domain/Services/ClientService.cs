using Estacionamento.Domain.Contracts.Base;
using Estacionamento.Domain.Contracts.Notificator;
using Estacionamento.Domain.Contracts.Services;
using Estacionamento.Domain.Enums;
using Estacionamento.Domain.Models.Bussiness;
using Estacionamento.Domain.Services.Base;
using Estacionamento.Domain.Validations;
using FluentValidation.Results;

namespace Estacionamento.Domain.Services
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
            if (!IsValid(new ClientValidation(), entity))
            {
                await _logRepository.SaveAsync(entity as Log);
                return await Task.FromResult<Client>(null);
            }

            await _logRepository.SaveAsync(entity as Log);

            return await base.SaveAsync(entity);
        }

        public override async Task<Client> UpdateAsync(Client entity)
        {
            if (!IsValid(new ClientValidation(), entity))
            {
                await _logRepository.SaveAsync(entity as Log);  
                return await Task.FromResult<Client>(null);     
            }

            await _logRepository.SaveAsync(entity as Log);
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

        private async Task teste(string name)
        {
            var client = await _repository.GetByExpressionAsync(e => e.Name == name);
            var time = 0;
            var amount = 10;

            client.ToList().ForEach(e =>
            {
                time += e.TimeInUseWithOutFee.Value.Hours;
            });

            if (time > 10)
                amount /= 2;
        }
    }
}
