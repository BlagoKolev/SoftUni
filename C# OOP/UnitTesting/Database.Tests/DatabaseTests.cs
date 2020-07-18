using System;
using NUnit.Framework;



namespace Database
{
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
             database = new Database(1, 2, 3);
        }

        [Test]
        public void CheckWheterConstructorWorksCorrect()
        {
            database.Add(4);

            var expectedCount = 4;
            var realCount = database.Count;

            Assert.AreEqual(expectedCount, realCount);
        }
        [Test]
        public void ConstructorMustThrowExceptionIfCollectionIsBiggerThenCapacity()
        {
            Assert.Throws<InvalidOperationException>(() =>
{
    var database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
});

        }

        [Test]
        public void AddMustThrowExceptionIfArrayAllreadyHasMaxCapacity()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            });
        }


        [Test]
        public void RemoveMustDecreseArrayCountByOneElement()
        {

            database.Remove();
            var expectedCount = 2;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void RemoveShouldThrownExceptionIfArrayIsEmpty()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });

        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] {1,2,3,4,5})]
        public void FetchShouldReturnCopyOfDatabase(int[] expectedData)
        {
            database = new Database(expectedData);
            var copyOfDatabase = database.Fetch();

            CollectionAssert.AreEqual(expectedData, copyOfDatabase);
        }
    }
}