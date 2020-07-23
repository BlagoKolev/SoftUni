namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;
      

        [Test]
        public void CheckFishConstructorWorksProperly()
        {
            var name = "Riba";
            fish = new Fish(name);
            Assert.AreEqual(fish.Name, name);

        }

        [Test]
        public void CheckAquariumConstructorWorksProperly()
        {

            var expectedName = "Ocean";
            var expectedCapacity = 100;
            Aquarium aquarium = new Aquarium("Ocean", 100);
            Assert.AreEqual(expectedName, aquarium.Name);
            Assert.AreEqual(expectedCapacity, aquarium.Capacity);
        }

        [Test]

        public void CheckNameThrowsExceptionIfValueIsNull()
        {
            string name = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 100);
            });
        }
        [Test]
        public void CheckNameThrowsExceptionIfValueIsEmpty()
        {
            string name = string.Empty;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 100);
            });
        }
        [Test]
        public void CheckCapacityThrowsExceptionIfValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var name = "Ocean";
                Aquarium aquarium = new Aquarium(name, -5);
            });
        }

        [Test]
        public void CheckWheterCountReturnProperlyValue()
        {
            fish = new Fish("Shark");
            var fish2 = new Fish("Octopus");
            var fish3 = new Fish("Cancer");
            aquarium = new Aquarium("Ocean", 100);
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            var expectedCount = 3;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }
        [Test]
        public void CheckAddFishThrowsExceptionIfCapacityIsFull()
        {
            aquarium = new Aquarium("Ocean", 1);
            fish = new Fish("Shark");
            aquarium.Add(fish);
            var fish2 = new Fish("SwordFish");

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);

            });
        }
        [Test]
        public void CheckWheterRemoveWorkProperly()
        {
            aquarium = new Aquarium("Ocean", 10);
            fish = new Fish("Shark");
            var fish2 = new Fish("Shark2");
            var fish3 = new Fish("Shark3");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.RemoveFish("Shark");
            aquarium.RemoveFish("Shark2");

            var expectedFishCountInAqurium = 1;

            Assert.AreEqual(expectedFishCountInAqurium, aquarium.Count);
        }
        [Test]
        public void CheckWheterRemoveThrowsExceptionIfFishIsNull()
        {
            aquarium = new Aquarium("Ocean", 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("fish");
            });
        }
        [Test]
        public void CheckWheterSellFishWorksProperly()
        {
            aquarium = new Aquarium("Ocean", 10);

            fish = new Fish("Elephant");
            aquarium.Add(fish);
            var returnedFish = aquarium.SellFish("Elephant");

            Assert.AreSame(fish, returnedFish);
            Assert.That(fish.Available == false);
        }
        [Test]
        public void CheckWheterSellFishThrowsExceptionIfFishIsNull()
        {
            aquarium = new Aquarium("Ocean", 10);
            fish = new Fish("Elephant");

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Elephant");
            });
        }
        [Test]
        public void CheckWheterReportReturnCorrectString()
        {
            fish = new Fish("Shark");
            var fish2 = new Fish("Shark2");
            aquarium = new Aquarium("Ocean", 10);
            aquarium.Add(fish);
            aquarium.Add(fish2);

            var expectedOutput = "Fish available at Ocean: Shark, Shark2";
            var result = aquarium.Report();

            Assert.AreEqual(expectedOutput, result);
        }
    }
}
