using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckConstructorWorksCorrect()
        {
            car = new Car("BMW", "E90", 0.5, 60);

            Assert.AreEqual("BMW", car.Make);
            Assert.AreEqual("E90", car.Model);
            Assert.AreEqual(0.5, car.FuelConsumption);
            Assert.AreEqual(60, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);

        }

        [Test]
        public void CheckWheterMakeThrowsArgumentExceptionIfValueIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("", "E90", 0.5, 60);
            });
        }
        [Test]
        public void CheckWheterModelThrowsArgumentExceptionIfValueIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("BMW", "", 0.5, 60);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CheckWheterFuelConsumptionThrowsExceptionIfValueIsLessOrEqalsToZero(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("BMW", "E90", fuelConsumption, 60);
            });
        }

        
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CheckWheterFuelCapacityThrowsExceptionIfValueIsEqualOrLessThanZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("BMW", "E90", 0.5, fuelCapacity);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CheckWheterRefuelMethodThrowsExceptionIfArgumentIsLessOrEqualsToZero(double fuelToRefuel)
        {
            car = new Car("BMW", "E90", 0.5, 60);
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });
        }

        [Test]
        public void CheckWheterRefuelWorksCorrectWhenRefuelingIsMoreThenCapacity()
        {
            car = new Car("BMW", "E90", 0.5, 60);
            car.Refuel(70);
            var expectedFuelInTank = 60;
            var realFuelInTank = car.FuelAmount;

            Assert.AreEqual(expectedFuelInTank, realFuelInTank);
        }
        [Test]
        public void CheckWheterRefuelWorksCorrect()
        {
            car = new Car("BMW", "E90", 0.5, 60);
            car.Refuel(30);
            var expectedFuelInTank = 30;
            var realFuelInTank = car.FuelAmount;

            Assert.AreEqual(expectedFuelInTank, realFuelInTank);
        }

        [Test]
        public void CheckWheterDriveWorksCorrect()
        {
            car = new Car("BMW", "E90", 5, 60);
            car.Refuel(30);
            car.Drive(10);
            var expectedFuelAmount =29.5;
            var realFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, realFuelAmount);
        }

        [Test]
        public void CheckWheterDriveWorksCorrectWithDistanceEqualToZero()
        {
            car = new Car("BMW", "E90", 5, 60);
            car.Refuel(10);
            car.Drive(10);
            var expectedFuelAmount = 10;
            var realFuelAmount = 10;
            Assert.AreEqual(expectedFuelAmount, realFuelAmount);
        }

        [Test]
        public void ChechWheterDriveWorksCorrectIfFuelAmountIsNotEnoughtToTakeTheDistance()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                car = new Car("BMW", "E90", 10, 60);
                car.Refuel(10);
                car.Drive(200);
            });
        }
    }
}