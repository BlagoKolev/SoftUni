namespace Presents.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        [SetUp]
        public void SetUp()
        {
            string name = "TV";
            double magic = 10.00;
            Present present = new Present(name, magic);
        }

        [Test]
        public void CheckPresentClassConstructorWorksProperly()
        {
            string name = "TV";
            double magic = 10.00;
            Present present = new Present(name, magic);
            string expectedName = "TV";
            double expectedMagic = 10.00;

            Assert.AreEqual(expectedName, present.Name);
            Assert.AreEqual(expectedMagic, present.Magic);
        }

        [Test]
        public void CheckBagCostructorInitializeACollectionProperly()
        {
            string name = "TV";
            double magic = 10.00;
            Present present = new Present(name, magic);
            Bag bag = new Bag();
            bag.Create(present);

            Assert.AreEqual(1, bag.GetPresents().Count);
        }
        [Test]
        public void CheckCreateThrowsExceptionIfPesentIsNull()
        {
            present = null;
            Bag bag = new Bag();

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });

        }
        [Test]
        public void CheckCreateThrowsExceptionIfAlreadyHasTheSamePresentInCollection()
        {
            string name = "TV";
            double magic = 10.00;
            Present present = new Present(name, magic);
            var bag = new Bag();
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });

        }
        [Test]
        public void CheckRemoveWorksProperly()
        {
            var bag = new Bag();
            Present present1 = new Present("name1", 1.00);
            Present present2 = new Present("name2", 1.00);
            bag.Create(present1);
            bag.Create(present2);
            bag.Remove(present2);
            Assert.AreEqual(1, bag.GetPresents().Count);
        }
        [Test]
        public void CheckRemoveReturnTheSameObjectAsExpected()
        {
            var bag = new Bag();
            Present present1 = new Present("name1", 1.00);
            Present present2 = new Present("name2", 1.00);
            bag.Create(present1);
            bag.Create(present2);
           var removedPresent = bag.Remove(present2);

            Assert.IsTrue(removedPresent);
        }
        [Test]
        public void CheckGetPresentWithLeastMagicReturnProperResult()
        {
            var bag = new Bag();
            Present present1 = new Present("name1", 1.00);
            Present present2 = new Present("name2", 11.00);
            bag.Create(present1);
            bag.Create(present2);
            var searchedPresent = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(searchedPresent, present1);
        }

        [Test]
        public void CheckGetPresentReturnProperlyPresentByGivenName()
        {
            var bag = new Bag();
            Present present1 = new Present("name1", 1.00);
            Present present2 = new Present("name2", 1.00);
            bag.Create(present1);
            bag.Create(present2);

            var searchedPresent = bag.GetPresent("name1");

            Assert.AreEqual(searchedPresent, present1);
        }
    }
}
