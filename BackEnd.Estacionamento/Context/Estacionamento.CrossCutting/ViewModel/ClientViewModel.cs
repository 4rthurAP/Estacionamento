namespace Estacionamento.CrossCutting.ViewModel
{
    public record ClientViewModel
    {
        public ClientViewModel()
        {

        }

        public int? Id { get; init; }
        public string Name { get; init; }
        public string Car { get; init; }
        public string Plate { get; init; }
        public short? Status { get; init; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
    }
}
