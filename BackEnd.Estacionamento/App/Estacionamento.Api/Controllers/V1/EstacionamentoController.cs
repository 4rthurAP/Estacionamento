using AutoMapper;
using Estacionamento.Api.Controllers.Main;
using Estacionamento.CrossCutting.Dto;
using Estacionamento.CrossCutting.ViewModel;
using Estacionamento.Domain.Contracts.Notificator;
using Estacionamento.Domain.Contracts.Services;
using Estacionamento.Domain.Enums;
using Estacionamento.Domain.Models.Bussiness;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionamentoController : MainController
    {
        private readonly IClientService _service;
        public EstacionamentoController(INotificator notificator, IMapper mapper, IClientService service) : base(notificator, mapper)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientViewModel viewModel) =>
            CustomResponse(_mapper.Map<ClientDto>(await _service.SaveAsync(_mapper.Map<Client>(viewModel))));

        [HttpPut]
        public async Task<IActionResult> Put(ClientViewModel viewModel) =>
            CustomResponse(_mapper.Map<ClientDto>(await _service.UpdateAsync(_mapper.Map<Client>(viewModel))));

        [HttpGet("Plate/{plate}")]
        public async Task<IActionResult> Get([FromRoute] string plate) =>
            CustomResponse(_mapper.Map<IEnumerable<ClientDto>>(await _service.GetByPlate(plate)));

        [HttpGet("Status/{status:int}")]
        public async Task<IActionResult> Get([FromRoute] int status) =>
            CustomResponse(_mapper.Map<IEnumerable<ClientDto>>(await _service.GetByStatus((Status)status)));

        [HttpGet]
        public async Task<IActionResult> Get() =>
            CustomResponse(await _service.Get());

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return CustomResponse();
        }
    }
}
