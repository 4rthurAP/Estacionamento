namespace Estacionamento.Domain.Models.Base
{
    public record BaseEntity
    {
        public BaseEntity()
        {

        }

        public int? Id { get; init; }
    }
  
}
