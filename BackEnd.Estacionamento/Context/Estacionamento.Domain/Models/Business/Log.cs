using Estacionamento.Domain.Models.Base;

namespace Estacionamento.Domain.Models.Bussiness
{
    public record Log : BaseEntity
    {
        public Log()
        {

        }
        public string Name { get; init; }
        public string Car { get; init; }
        public string Plate { get; init; }
        public DateTime? TimeIn { get; init; }
        public DateTime? TimeOut { get; init; }
    }
}
