namespace Presents.Tests
{
    using System;
    using NUnit.Framework;

    public class PresentsTests
    {
        private Present present;
        private Bag bag;
        private string name;
        private int magic = 10;

        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();
            this.present = new Present(name, magic);
        }

        [Test]
        public void CheckCreateMEthodWorksProperly()
        {
            this.bag.Create(this.present);

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, this.bag.GetPresents().Count);
        }
        [Test]
        public void CheckCreateThrowsArgumentNullExceptionIfPresentIsNull()
        {
            Present present2 = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.bag.Create(present2);
            });
        }
        [Test]
        public void CheckCreateThrowsInvalidOperationExceptionIfPresentAlreadyExist()
        {
            this.bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.bag.Create(present);
            });
        }
        [Test]
        public void CheckRemoveWorksProperly()
        {
            Present present2 = new Present("a", 4);
            this.bag.Create(present);
            this.bag.Create(present2);
            this.bag.Remove(present2);
            var expectedCount = 1;
            
            Assert.AreEqual(expectedCount, this.bag.GetPresents().Count);
        }
        [Test]
        public void CheckFindPresenstWithLessMagicWorksProperly()
        {
            Present present2 = new Present("a", 4);
            this.bag.Create(present);
            this.bag.Create(present2);

            var searchedPResent = this.bag.GetPresentWithLeastMagic();

            Assert.AreEqual(present2, searchedPResent);
        }
        [Test]
        public void CheckIfGetPresentReturnCorrectPResent()
        {
            Present present2 = new Present("a", 4);
            this.bag.Create(present);
            this.bag.Create(present2);

            var searchedPResent = this.bag.GetPresent("a");

            Assert.AreEqual(present2, searchedPResent);
        }
    }
}
