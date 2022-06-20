using Estacionamento.Domain.Models.Base;

namespace Estacionamento.Domain.Models.Bussiness
{
    public record Log : BaseEntity
    {
        public Log()
        {

        }
        
        public string Path { get; init; }
        public string Objeto { get; init; }
        public string Host { get; init; }
        public string Trace { get; init; }
        
        #region nao utilizados
            public string Car { get; init; }
            public string Plate { get; init; }
            public DateTime? TimeIn { get; init; }
            public DateTime? TimeOut { get; init; }
            public string Name { get; init; }
        #endregion
    }
}
