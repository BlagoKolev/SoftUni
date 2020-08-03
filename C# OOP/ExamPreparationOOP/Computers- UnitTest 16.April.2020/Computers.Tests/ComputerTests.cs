namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    public class ComputerTests
    {
        private string computerName = "IBM";
        private Computer computer;
        private Part part;
        private string partName = "Mouse";
        private decimal price = 10m;

        [SetUp]
        public void Setup()
        {
             this.computer = new Computer(computerName);
            this.part = new Part(partName, price);
        }

        [Test]
        public void CheckComputerConstructorSetProperName()
        {
            var expectedName = "IBM";

            Assert.AreEqual(expectedName, this.computer.Name);
        }
        [Test]
        [TestCase(null)]
        [TestCase("  ")]
        public void CheckIfComputerNameThrowsExceptionIfNameIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer1 = new Computer(name);
            });
        }
        [Test]
        public void CheckIfAddWorksProperly()
        {
            this.computer.AddPart(this.part);
            var expectedCount = 1;

            Assert.AreEqual(expectedCount, this.computer.Parts.Count);
        }
        [Test]
        public void CheckIfAddThrowsExceptionIfPartIsNull()
        {
            Part part2 = null;
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.computer.AddPart(part2);
            });
        }
        [Test]
        public void CheckIfRemoveWorksProperly()
        {
            Part part2 = new Part("RRR",23);
            this.computer.AddPart(part);
            this.computer.AddPart(part2);
            this.computer.RemovePart(part2);

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, this.computer.Parts.Count);
        }
        [Test]
        public void CheckIfGetPartReturnCorectPart()
        {
            Part part2 = new Part("RRR", 23);
            this.computer.AddPart(part);
            this.computer.AddPart(part2);
            var searchedPart = this.computer.GetPart("RRR");

            Assert.AreEqual(part2,searchedPart );
        }
        [Test]
        public void CheckIfTotalPriceReturnCorrectResult()
        {
            Part part2 = new Part("RRR", 23);
            this.computer.AddPart(part);
            this.computer.AddPart(part2);

            var actualSum = this.computer.TotalPrice;
            var expectedSum = 33m;

            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}