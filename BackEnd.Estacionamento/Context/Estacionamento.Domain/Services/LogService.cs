using Estacionamento.Domain.Contracts.Base;
using Estacionamento.Domain.Contracts.Notificator;
using Estacionamento.Domain.Contracts.Services;
using Estacionamento.Domain.Models.Bussiness;
using Estacionamento.Domain.Service.Base;

namespace Estacionamento.Domain.Services
{
    public class LogService : Service<Log>, ILogService
    {
        public LogService(INotificator notificator, IRepository<Log> repository) : base(notificator, repository)
        {
        }

        public async override Task<IEnumerable<Log>> Get()
        {
            return await base.Get();
        }
    }
}
