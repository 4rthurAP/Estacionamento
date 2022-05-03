using Bogus;
using Estacionamento.Domain.Enums;
using Estacionamento.Domain.Models.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Test.Build
{
    public static class Factory
    {
        public static Client NewClientActiveAndFree()
        {
            return new Client()
            {
                TimeIn = new(2022, 04, 27, 11, 30, 00),
                TimeOut = new(2022, 04, 27, 13, 30, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }

        public static Client NewClientActiveAndNotFree()
        {
            return new Client()
            {
                TimeIn = new(2022, 05, 2, 13, 30, 00),
                TimeOut = new(2022, 05, 2, 17, 30, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }

        public static Client NewClientTime10h30m()
        {
            return new Client()
            {
                TimeIn = new(2022, 05, 2, 06, 00, 00),
                TimeOut = new(2022, 05, 2, 18, 00, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }

        public static Client NewClientTime5h30m()
        {
            return new Client()
            {
                TimeIn = new(2022, 05, 2, 06, 00, 00),
                TimeOut = new(2022, 05, 2, 13, 00, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }        
        
        public static Client NewClientLessThan30m()
        {
            return new Client()
            {
                TimeIn = new(2022, 05, 1, 06, 00, 00),
                TimeOut = new(2022, 05, 1, 06, 25, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }        
        
        public static Client NewClientLessThan24hIn2days()
        {
            return new Client()
            {
                TimeIn = new(2022, 05, 1, 13, 00, 00),
                TimeOut = new(2022, 05, 2, 13, 00, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }

        public static Client NewClientTime1h30m()
        {
            return new Client()
            {
                TimeIn = new(2022, 05, 2, 06, 00, 00),
                TimeOut = new(2022, 05, 2, 07, 30, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }

        public static Client NewClientTime3h30m()
        {
            return new Client()
            {
                TimeIn = new(2022, 05, 2, 13, 00, 00),
                TimeOut = new(2022, 05, 2, 16, 30, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }

        public static Client NewClientMoreThanOneDay()
        {
            return new Client()
            {
                TimeIn = new(2022, 05, 5, 00, 00, 00),
                TimeOut = new(2022, 05, 8, 00, 00, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }

        public static Client NewClientTime3h30mOutOfFreeDays()
        {
            return new Client()
            {
                TimeIn = new(2022, 05, 2, 13, 00, 00),
                TimeOut = new(2022, 05, 2, 16, 30, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }


        public static Client NewClient() => new();
       
    }
}
