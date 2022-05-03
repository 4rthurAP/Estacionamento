using Estacionamento.Domain.Enums;
using Estacionamento.Domain.Models.Base;

namespace Estacionamento.Domain.Models.Bussiness
{
    public record Client : BaseEntity
    {
        public Client() { }

        public string Name { get; init; }
        public string Car { get; init; }
        public string Plate { get; init; }
        public Status? Status { get; init; }
        public DateTime? TimeIn { get; init; }
        public DateTime? TimeOut { get; init; }
        public double? Amount => (double)Decimal.Round((decimal)GetValue(), 2);
        private double SameDay() => IsSameDay ? TotalTimeInUse.Value.Hours == 0 ? TotalTimeInUse.Value.Minutes * 0.01 : TotalTimeInUse.Value.Hours : TimeInUseWithOutFee.Value.TotalHours;
        public bool IsFree => Amount == 0;
        public bool IsSameDay => !(TimeOut.Value.Date > TimeIn.Value.Date);
        public TimeSpan? TotalTimeInUse => TimeOut - TimeIn;
        public TimeSpan? TimeToSafe => IsSameDay ? TotalTimeInUse.Value : TimeInUseWithOutFee.Value;
        public TimeSpan? TimeInUseWithOutFee => GetTimeSpan();
        public List<DateTime> ListDays => SumDates();
        public List<DayOfWeek> DaysFree => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Thursday };

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
            return SameDay() <= 1 ?  1 : SameDay() * 2;
        }

        private TimeSpan? GetTimeSpan()
        {
            TimeSpan? time = new();

            ListDays.ForEach(e => { time += CalculateTime(e); });

            return time;
        }

        private TimeSpan? CalculateTime(DateTime dateTime, double min = 11.50, double max = 13.00)
        {
            TimeSpan? time = new();

            var timeIn = TimeIn;
            var timeOut = TimeOut;
            
            if (DaysFree.Contains(dateTime.DayOfWeek))
            {
                if (dateTime.TimeOfDay > TimeSpan.FromHours(min) || dateTime.TimeOfDay < TimeSpan.FromHours(max))
                {
                    time = timeOut - timeIn;
                    if (timeIn.Value.TimeOfDay < TimeSpan.FromHours(min) && timeOut.Value.TimeOfDay < TimeSpan.FromHours(max) && IsSameDay)
                    {
                        if (time > TimeSpan.FromHours(1.50))
                        {
                            var timeToRemove = timeOut.Value.TimeOfDay - TimeSpan.FromHours(min);
                            time += timeToRemove * -1;
                        }
                    }
                    else if (timeOut.Value.TimeOfDay <= TimeSpan.FromHours(max))
                    {
                        var timeToRemove = timeOut.Value.TimeOfDay - TimeSpan.FromHours(min);
                        var timeToCalculate  =  IsSameDay ? timeToRemove * -1 : - TimeSpan.FromHours(1.50);
                        time += timeToCalculate ;
                    }
                    else if (timeIn.Value.TimeOfDay > TimeSpan.FromHours(min) || timeOut.Value.TimeOfDay < TimeSpan.FromHours(max))
                    {                       
                    }
                    else
                    {
                        time -= TimeSpan.FromHours(1.50);
                    }
                }
            }
            else
            {
                if (IsSameDay)
                    time = timeOut - timeIn;
            }

            if (dateTime.TimeOfDay.Minutes > 10)
            {
                time = TimeSpan.FromHours(1);
            }

            return time;
        }
    }
}
