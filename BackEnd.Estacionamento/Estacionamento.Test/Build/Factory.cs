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
                TimeIn = new(2022, 05, 1, 13, 30, 00),
                TimeOut = new(2022, 05, 1, 17, 30, 00),
                Name = "Arthur",
                Plate = "Plate",
                Status = Status.Active,
                Car = "Voyage",
            };
        }

        public static Client NewClient() => new();
       
    }
}
