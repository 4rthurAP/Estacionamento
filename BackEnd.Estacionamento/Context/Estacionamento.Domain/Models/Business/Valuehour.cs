namespace Estacionamento.Domain.Models.Bussiness
{
    public record Valuehour
    {
        public Valuehour()
        {

        }
        public int Id { get; init; }
        public decimal? Value { get; init; }
        public TimeSpan? Time { get; init; }

    }
}
