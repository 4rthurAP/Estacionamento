using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.CrossCutting.Dto
{
    public record ClientDto
    {
        public ClientDto()
        {

        }

        public int? Id { get; init; }
        public string Name { get; init; }
        public string Car { get; init; }
        public double? Amount { get; init; }
        public bool IsFree { get; init; }
        public TimeSpan? TimeInUseWithOutFee { get; init; }
        public TimeSpan? TotalTimeInUse { get; init; }
        public string Plate { get; init; }
        public short? Status { get; init; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
    }

}