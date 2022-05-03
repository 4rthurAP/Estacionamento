using Estacionamento.Domain.Models.Bussiness;
using Estacionamento.Test.Build;
using FluentAssertions;
using System;
using Xunit;

namespace Estacionamento.Test.Domain.Models
{
    public class ClientTest
    {
        [Fact]
        public void TestClientActiveAndFree()
        {
            //Act
            var client = Factory.NewClientActiveAndFree();

            //Arrange & Assert
            client.IsFree.Should().BeTrue(because: "When the days and the hours that have been parameterized this prop should be true");
        }

        [Fact]
        public void TestClientActiveAndNotFree()
        {
            //Act
            var client = Factory.NewClientActiveAndNotFree();

            //Arrange & Assert
            client.IsFree.Should().BeFalse(because: "When the days and the hours that have been parameterized this prop should be false");
        }


        [Fact]
        public void TestClientTime10h30m()
        {
            //Act
            var client = Factory.NewClientTime10h30m();

            //Arrange & Assert
            client.TimeInUseWithOutFee.Should().Be(TimeSpan.FromHours(10.50));
        }

        [Fact]
        public void TestClientTime5h30m()
        {
            //Act
            var client = Factory.NewClientTime5h30m();

            //Arrange & Assert
            client.TimeInUseWithOutFee.Should().Be(TimeSpan.FromHours(5.50));
        }

        [Fact]
        public void TestClientTime1h30m()
        {
            //Act
            var client = Factory.NewClientTime1h30m();

            //Arrange & Assert
            client.TimeInUseWithOutFee.Should().Be(TimeSpan.FromHours(1.50));
        }     
        
        [Fact]
        public void TestClientTime3h30m()
        {
            //Act
            var client = Factory.NewClientTime3h30m();

            //Arrange & Assert
            client.TimeInUseWithOutFee.Should().Be(TimeSpan.FromHours(3.50));
        }

        [Fact]
        public void TestClientTimeMoreThanOneDay()
        {
            //Act
            var client = Factory.NewClientMoreThanOneDay();

            //Arrange & Assert
            client.Amount.Should().Be(141);
        }

        [Fact]
        public void TestClientTimeLessThan30m()
        {
            //Act
            var client = Factory.NewClientLessThan30m();

            //Arrange & Assert
            client.Amount.Should().Be(1);
        }

        [Fact]
        public void TestClientTimeLessThan24hIn2days()
        {
            //Act
            var client = Factory.NewClientLessThan24hIn2days();

            //Arrange & Assert
            client.TimeInUseWithOutFee.Should().Be(TimeSpan.FromHours(22.5));
        }


        [Fact]
        public void TestClientTime3h30mOutOfFreeDays()
        {
            //Act
            var client = Factory.NewClientTime3h30mOutOfFreeDays();

            //Arrange & Assert
            client.TimeInUseWithOutFee.Should().Be(TimeSpan.FromHours(3.50));
        }


        [Fact]
        public void TestClientShouldNotThrowExeption()
        {
            //Act
            var client = Factory.NewClient();

            //Arrange & Assert
            client.Should().NotBeNull(because: "This is an Ivoke of object");
        }
    }
}
