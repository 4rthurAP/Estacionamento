using AutoMapper;
using Estacionamento.Domain.Contracts.Notificator;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Estacionamento.Api.Controllers.Main
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificator _notificator;
        protected readonly IMapper _mapper;
        protected MainController(INotificator notificator, IMapper mapper)
        {
            _notificator = notificator;
            _mapper = mapper;
        }

        protected bool IsValid() =>
            !_notificator.HasNotifications();

        protected IActionResult CustomResponse(object result = null) =>
            IsValid() ? Ok(new { success = true, data = result }) :
             BadRequest(new { success = false, errors = _notificator.GetNotifications().Select(n => n.ErrorMessage) });
    }
}
