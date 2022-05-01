using Estacionamento.Domain.Enums;
using Estacionamento.Domain.Models.Base;

namespace Estacionamento.Domain.Models.Bussiness
{
    public record Client : BaseEntity
    {
        public Client() {}

        public string Name { get; init; }
        public string Car { get; init; }
        public string Plate { get; init; }
        public Status? Status { get; init; }
        public double? Amount => GetValue();
        public bool HasDiscount => IsSameDay ? TotalTimeInUse.Value.Hours > 10 : TimeInUseWithOutFee.Value.Hours > 10;
        public DateTime? TimeIn { get; init; }
        public DateTime? TimeOut { get; init; }
        public TimeSpan? TimeInUseWithOutFee => GetTimeSpan();
        public bool IsSameDay => TimeInUseWithOutFee < TimeSpan.FromHours(24);
        public TimeSpan? TotalTimeInUse => TimeOut - TimeIn;
        public List<DateTime> ListDays => SumDates();
        public List<DayOfWeek> DaysFree => new List<DayOfWeek>() { DayOfWeek.Sunday, DayOfWeek.Wednesday, DayOfWeek.Thursday };
        public bool IsFree => Amount == 0;

        private List<DateTime> SumDates()
        {
            List<DateTime> sumDates = new();
            var timeIn = TimeIn;
            var timeOut = TimeOut;
            sumDates.Add(timeIn.Value);

            while (timeIn.Value.Date < timeOut.Value.Date)
            {
                sumDates.Add(timeIn.Value.AddDays(1));
                timeIn = timeIn.Value.AddDays(1);
            }

            return sumDates;
        }

        private double GetValue(double min = 11.30, double max = 13.00)
        {
            if (ListDays.Count == 1)  
                if (DaysFree.Contains(ListDays.FirstOrDefault().DayOfWeek))
                    if (ListDays.FirstOrDefault().TimeOfDay >= TimeSpan.FromHours(min) && ListDays.FirstOrDefault().TimeOfDay <= TimeSpan.FromHours(max))
                        return 0;

            if (HasDiscount)
                return SameDay();

            return SameDay() * 2;
        }

        private double SameDay() => IsSameDay ? TotalTimeInUse.Value.Hours : TimeInUseWithOutFee.Value.Hours;

        private TimeSpan? GetTimeSpan()
        {
            TimeSpan time = new();

            ListDays.ForEach(e => { time = CalculateTime(e); });

            return time;
        }

        private TimeSpan CalculateTime(DateTime dateTime)
        {
            TimeSpan time = new();

            if (DaysFree.Contains(dateTime.DayOfWeek))
            {
                if (dateTime.TimeOfDay > TimeSpan.FromHours(11.30) && dateTime.TimeOfDay < TimeSpan.FromHours(13.00))
                {
                    time += (dateTime.TimeOfDay - TimeSpan.FromHours(1.30));
                }
            }
            else
            {
                time += dateTime.TimeOfDay;
            }

            if (dateTime.TimeOfDay.Minutes > 10)
            {
                time += TimeSpan.FromHours(1);
            }

            return time;
        }
    }
}
