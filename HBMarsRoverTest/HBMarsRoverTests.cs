using HBMarsRover;
using NUnit.Framework;
using System;

namespace Tests
{
    public class HBMarsRoverTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Arrange
            string mapSize = "5 5";
            string initialPosition = "1 2 N";
            string finalPosition = "1 3 N";
            string command = "LMLMLMLMM";
            // Act
            Rover rover = new Rover(mapSize);
            rover.SetPosition(initialPosition);
            rover.CommandExecute(command);
            // Assert
            Assert.AreEqual(rover.GetPosition(), finalPosition);

        }

        [Test]
        public void Test2()
        {
            // Arrange
            string mapSize = "5 5";
            string initialPosition = "3 3 E";
            string finalPosition = "5 1 E";
            string command = "MMRMMRMRRM";

            // Act
            Rover rover = new Rover(mapSize);
            rover.SetPosition(initialPosition);
            rover.CommandExecute(command);
            // Assert
            Assert.AreEqual(rover.GetPosition(), finalPosition);

        }

        [Test]        
        public void Should_ThrowException_ForInvalidMapSize()
        {
            // Arrange
            string mapSize = "5 -5";

            // Act
            var ex = Assert.Throws<Exception>(() => { Rover rover = new Rover(mapSize); });

            // Assert
            Assert.That(ex.Message == "Invalid size.");
        }

        [Test]
        public void Should_ThrowException_ForInvalidCommand()
        {
            // Arrange
            string mapSize = "5 5";
            string initialPosition = "3 3 E";
            string command = "MMRMM                                         RMRRM";

            // Act
            Rover rover = new Rover(mapSize);
            rover.SetPosition(initialPosition);
            var ex = Assert.Throws<Exception>(() => { rover.CommandExecute(command); });

            // Assert
            Assert.That(ex.Message == "Invalid command.");

        }
        [Test]
        public void Should_ThrowException_ForInvalidXPosition()
        {
            // Arrange
            string mapSize = "5 5";
            string initialPosition = "-3 3 E";

            // Act
            Rover rover = new Rover(mapSize);
            var ex = Assert.Throws<Exception>(() => { rover.SetPosition(initialPosition); });

            // Assert
            Assert.That(ex.Message == "Invalid X position.");

        }

        [Test]
        public void Should_ThrowException_ForInvalidYPosition()
        {
            // Arrange
            string mapSize = "5 5";
            string initialPosition = "3 -3 E";

            // Act
            Rover rover = new Rover(mapSize);
            var ex = Assert.Throws<Exception>(() => { rover.SetPosition(initialPosition); });

            // Assert
            Assert.That(ex.Message == "Invalid Y position.");

        }

        [Test]
        public void Should_ThrowException_ForInvalidDirection()
        {
            // Arrange
            string mapSize = "5 5";
            string initialPosition = "3 3 Y";

            // Act
            Rover rover = new Rover(mapSize);
            var ex = Assert.Throws<Exception>(() => { rover.SetPosition(initialPosition); });

            // Assert
            Assert.That(ex.Message == "Invalid Direction.");
        }
    }
}