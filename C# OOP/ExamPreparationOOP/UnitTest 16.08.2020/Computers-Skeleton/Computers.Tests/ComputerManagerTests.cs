using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer comp1;
        private Computer comp2;
        private ComputerManager cm;

        [SetUp]
        public void Setup()
        {
            this.comp1 = new Computer("IBM", "a", 10);
            this.comp2 = new Computer("ASUS", "b", 20);
            this.cm = new ComputerManager();
        }

        [Test]
        public void CheckComputerClass()
        {
            var expectedManufactorer = "IBM";
            var expectedModel = "a";
            var expectedPrice = 10;
            Assert.AreEqual(expectedManufactorer, this.comp1.Manufacturer);
            Assert.AreEqual(expectedModel, this.comp1.Model);
            Assert.AreEqual(expectedPrice, this.comp1.Price);
            Assert.IsNotNull(comp1);
        }
        [Test]
        public void CheckConstructorOfComputerManager()
        {
            var expected = this.cm.Computers;
            Assert.IsNotNull(this.cm.Computers);
            Assert.IsTrue(expected is IReadOnlyCollection<Computer>);
            Assert.AreEqual(0, this.cm.Count);
            Assert.AreEqual(0, this.cm.Computers.Count);
        }
        [Test]
        public void CheckCountProperty()
        {
            Assert.AreEqual(0, this.cm.Count);
            Assert.AreEqual(0, this.cm.Computers.Count);
        }
        [Test]
        public void CheckAddWorksProperly()
        {
            this.cm.AddComputer(comp1);
            this.cm.AddComputer(comp2);
            Assert.AreEqual(2, this.cm.Computers.Count);
        }
        [Test]
        public void CheckAddThrowArgumenNullException()
        {
            Computer comp = null;

            Assert.Throws<ArgumentNullException>(() => this.cm.AddComputer(comp));
        }
        [Test]
        public void CheckAddThrowArgumentException()
        {
            this.cm.AddComputer(comp1);
            var comp = new Computer("IBM", "a", 55);
            Assert.Throws<ArgumentException>(() => this.cm.AddComputer(comp), "This computer already exists.");
        }
        [Test]
        public void CheckGetComputerWorksProper()
        {
            this.cm.AddComputer(comp1);
            this.cm.AddComputer(comp2);
            var comp = this.cm.GetComputer("IBM", "a");
            Assert.AreEqual(comp, comp1);
        }
        [Test]
        public void CheckGetComputerThrowsArgumeNullExceptionWithManufactorer()
        {
            this.cm.AddComputer(comp1);
            this.cm.AddComputer(comp2);
            Assert.Throws<ArgumentNullException>(() => this.cm.GetComputer(null, "a"));
        }
        [Test]
        public void CheckGetComputerThrowsArgumeNullExceptionWithModel()
        {

            this.cm.AddComputer(comp1);
            this.cm.AddComputer(comp2);
            Assert.Throws<ArgumentNullException>(() => this.cm.GetComputer("IBM", null));
        }
        [Test]
        public void CheckGetComputerThrowsArgumentExceptionIfNoSuchComputer()
        {

            this.cm.AddComputer(comp1);
            this.cm.AddComputer(comp2);
            Assert.Throws<ArgumentException>(() => this.cm.GetComputer("SOS", "z"), "There is no computer with this manufacturer and model.");
        }
        [Test]
        public void CheckRemoveReturnRightComputer()
        {
            this.cm.AddComputer(comp1);
            this.cm.AddComputer(comp2);
            var comp = this.cm.RemoveComputer("IBM", "a");
            Assert.AreEqual(comp, comp1);

        }
        [Test]
        public void CheckRemoveReduceTheCountInCollection()
        {
            this.cm.AddComputer(comp1);
            this.cm.AddComputer(comp2);
            var comp = this.cm.RemoveComputer("IBM", "a");
            Assert.AreEqual(1, this.cm.Count);
        }
        [Test]
        public void CheckGetByManufactorerThrowArgumenNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.cm.GetComputersByManufacturer(null));
        }
        [Test]
        public void CheckGetByManufactorerReturnRightCollection()
        {
            var comp3 = new Computer("IBM", "44", 100);
            var comp4 = new Computer("IBM", "444", 410);
            var comp5 = new Computer("IBM", "4444", 140);
            this.cm.AddComputer(comp1);
            this.cm.AddComputer(comp2);
            this.cm.AddComputer(comp3);
            this.cm.AddComputer(comp4);
            this.cm.AddComputer(comp5);

            ICollection<Computer> computers = this.cm.GetComputersByManufacturer("IBM");
            ICollection<Computer> expectedCollection = new List<Computer>(){ comp1,comp3,comp4,comp5};

            CollectionAssert.AreEqual(computers, expectedCollection);
            Assert.IsTrue(computers is List<Computer>);
            Assert.AreEqual(4, computers.Count);
        }
        [Test]
        public void AddValidComputer()
        {
            this.cm.AddComputer(this.comp1);

            Assert.IsNotNull(this.cm.Computers.FirstOrDefault(c => c.Manufacturer == "IBM"));
        }
        [Test]
        public void RemoveComputerWithNonExistingMan()
        {
            this.cm.AddComputer(this.comp1);
            this.cm.AddComputer(this.comp2);

            Assert.Throws<ArgumentException>(() => cm.RemoveComputer("Lenovo", "002"));
        }

        [Test]
        public void RemoveComputerWithNonExistingModel()
        {
           this.cm.AddComputer(this.comp1);
           this.cm.AddComputer(this.comp2);

            Assert.Throws<ArgumentException>(() => this.cm.RemoveComputer("IBM", "111"));
        }
    }
}