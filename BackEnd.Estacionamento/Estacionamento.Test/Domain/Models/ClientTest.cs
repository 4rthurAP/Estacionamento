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
        public void TestClientShouldNotThrowExeption()
        {
            //Act
            var client = Factory.NewClient();

            //Arrange & Assert
            client.Should().NotBeNull(because: "This is an Ivoke of object");
        }
    }
}
