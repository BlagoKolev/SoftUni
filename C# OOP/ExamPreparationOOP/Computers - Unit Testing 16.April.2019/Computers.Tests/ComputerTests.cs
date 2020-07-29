namespace Computers.Tests
{
    using System;
    using NUnit.Framework;

    public class ComputerTests
    {
        private Part part;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            Part part = new Part("Mouse", 10.00m);
            Computer computer = new Computer("Xiomi");
        }

        [Test]
        public void CheckWheterPartConstructorWorksProperly()
        {
            Part part = new Part("Mouse", 10.00m);

            var expectedName = "Mouse";
            var expectedPrice = 10.00m;

            Assert.AreEqual(expectedName, part.Name);
            Assert.AreEqual(expectedPrice, part.Price);
        }
        [Test]
        public void CheckWheterComputerNameIsCorectlyDoneByConstructor()
        {
            computer = new Computer("Xiomi");
            var expectedName = "Xiomi";

            Assert.AreEqual(expectedName, computer.Name);
        }

        [Test]
        public void CheckComputerConstructorWorksProperlyWithCollection()
        {
            computer = new Computer("Xiomi");
            part = new Part("mouse", 10m);
            var part2 = new Part("monitor", 100);
            computer.AddPart(part);
            computer.AddPart(part2);

            var expectedCount = 2;

            Assert.AreEqual(expectedCount, computer.Parts.Count);

        }
        [Test]
        [TestCase(null)]
        [TestCase("   ")]
        public void CheskWheterNameThrowsExceptionIfValueIsNullOrWhitespace(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
                {
                 computer = new Computer(name);
                });

        }
        [Test]
        public void CheckWheterSummatorPriceWorksProperly()
        {
            computer = new Computer("Xiomi");
            part = new Part("mouse", 10);
            var part2 = new Part("monitor", 91);
            var expectedPrice = 101m;
            computer.AddPart(part);
            computer.AddPart(part2);

            Assert.AreEqual(expectedPrice, computer.TotalPrice);
        }
        [Test]
        public void CheckWheterAddPartThrowsExceptionIfValueIsNull()
        {
            Part part = null;
            computer = new Computer("Xiomi");

            Assert.Throws<InvalidOperationException>(() =>
            {
                computer.AddPart(part);
            });
        }
        [Test]
        public void CheckRemoveWorksProperly()
        {
            computer = new Computer("xiomi");
            part = new Part("mouse", 10m);
           var part2 = new Part("mouse2", 10m);
           var part3 = new Part("mouse3", 10m);

            computer.AddPart(part);
            computer.AddPart(part2);
            computer.AddPart(part3);

            var expectedCount = 2;

            Assert.IsTrue(computer.RemovePart(part3));
            Assert.AreEqual(expectedCount, computer.Parts.Count);
        }

        [Test]  
        public void CheckWheterGetPartWorksProperly()
        {
            computer = new Computer("xiomi");
            part = new Part("mouse", 10m);
            var part2 = new Part("mouse2", 10m);
            var part3 = new Part("mouse3", 10m);

            computer.AddPart(part);
            computer.AddPart(part2);
            computer.AddPart(part3);

            var currentPart = computer.GetPart("mouse");

            Assert.AreEqual(part, currentPart);
        }
    }
}