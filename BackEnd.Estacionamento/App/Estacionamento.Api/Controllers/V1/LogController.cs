using AutoMapper;
using Estacionamento.Api.Controllers.Main;
using Estacionamento.Domain.Contracts.Base;
using Estacionamento.Domain.Contracts.Notificator;
using Estacionamento.Domain.Models.Bussiness;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : MainController
    {
        public readonly IService<Log> _log;
        public LogController(INotificator notificator, IMapper mapper, IService<Log> log) : base(notificator, mapper)
        {
            _log = log;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            CustomResponse(await _log.Get());
    }
}
