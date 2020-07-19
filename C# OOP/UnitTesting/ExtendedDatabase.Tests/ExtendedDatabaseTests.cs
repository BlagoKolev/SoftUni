using System;
using NUnit.Framework;

namespace ExtendedDatabase //Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDatabase;
        private Person person;

        [SetUp]
        public void Setup()
        { }

        [Test]
        public void CheckConstructorAddRangeCreateDatabaseCorrectly()
        {
            var persons = new Person[] { new Person(111, "A"), new Person(222, "B") };

            extendedDatabase = new ExtendedDatabase(persons);
            var expectedCount = persons.Length;
            var realCount = extendedDatabase.Count;
            Assert.AreEqual(expectedCount, realCount);
        }

        [Test]
        public void CheckConstructorAddRangeThrowsException()
        {

            var persons = new Person[]
            {
                new Person(01,"X"),
                new Person(02,"A"),
                 new Person(03,"B"),
                 new Person(04,"C"),
                 new Person(05,"D"),
                 new Person(06,"E"),
                 new Person(07,"F"),
                 new Person(08,"G"),
                 new Person(09,"H"),
                 new Person(10,"I"),
                 new Person(11,"J"),
                 new Person(12,"K"),
                 new Person(13,"L"),
                 new Person(14,"M"),
                 new Person(15,"N"),
                 new Person(16,"O"),
                 new Person(17,"P"),
                };

            Assert.Throws<ArgumentException>(() =>
            { extendedDatabase = new ExtendedDatabase(persons); });


        }

        [Test]
        public void CheckAddMethodThrowExceptionIfCapacityIsFull()
        {
            var persons = new Person[]
            {
                new Person(01,"X"),
                new Person(02,"A"),
                 new Person(03,"B"),
                 new Person(04,"C"),
                 new Person(05,"D"),
                 new Person(06,"E"),
                 new Person(07,"F"),
                 new Person(08,"G"),
                 new Person(09,"H"),
                 new Person(10,"I"),
                 new Person(11,"J"),
                 new Person(12,"K"),
                 new Person(13,"L"),
                 new Person(14,"M"),
                 new Person(15,"N"),
                 new Person(16,"O"),
                                 };

            extendedDatabase = new ExtendedDatabase(persons);
            var persom = new Person(1, "Z");

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Add(person);
            });
        }

        [Test]
        public void CheckAddMethodThrowExceptonIfThereIsAllredyUserWithSameName()
        {

            var persons = new Person[] { new Person(1, "A"), new Person(2, "B") };
            extendedDatabase = new ExtendedDatabase(persons);
            person = new Person(3, "A");

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Add(person);
            });
        }

        [Test]
        public void CheckAddMethodThrowExceptionIfThereAllreadyUserWithSameID()
        {
            var persons = new Person[] { new Person(1, "A"), new Person(2, "B") };
            extendedDatabase = new ExtendedDatabase(persons);
            person = new Person(1, "C");

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Add(person);
            });
        }

        [Test]
        public void CheckWheterAddMethodWorkCorrectAndAddAnotherUser()
        {
            var persons = new Person[] { new Person(1, "A"), new Person(2, "B") };

            extendedDatabase = new ExtendedDatabase(persons);
            person = new Person(3, "Z");

            extendedDatabase.Add(person);

            var expectedCount = 3;
            var realCount = extendedDatabase.Count;

            Assert.AreEqual(expectedCount, realCount);

        }

        [Test]
        public void CheckRemoveThrowExceptionIfCollectionIsEmpty()
        {
            extendedDatabase = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Remove();
            });
        }

        [Test]
        public void CheckRemoveWorksCorrect()
        {
            extendedDatabase = new ExtendedDatabase(new Person(1, "A"));
            extendedDatabase.Remove();
            var expectedCount = 0;
            var realCount = extendedDatabase.Count;

            Assert.AreEqual(expectedCount, realCount);
        }

        [Test]
        public void CheckFindByUserNameThrowExceptionIfNameIsNull()
        {
            var persons = new Person[] { new Person(1, "A"), new Person(2, "B") };
            extendedDatabase = new ExtendedDatabase(persons);
            string name = string.Empty;

            Assert.Throws<ArgumentNullException>(() =>
            {
                extendedDatabase.FindByUsername(name);
            });
        }

        [Test]
        public void CheckFindByUsernameThrowExceptionIfNoSuchPersonInCollection()
        {
           var persons = new Person[] { new Person(1, "A"), new Person(2, "B") };
            extendedDatabase = new ExtendedDatabase(persons);
            var name = "C";

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.FindByUsername(name);
            });
        }

        [Test]
       public void CheckFindByUsernameWorksCorrect()
        {
            var persons = new Person[] { new Person(1, "A"), new Person(2, "B") };
            extendedDatabase = new ExtendedDatabase(persons);
            var person = new Person(1, "A");
            var personName = person.UserName;

            var searchedPerson = extendedDatabase.FindByUsername(personName);

            Assert.AreEqual(person.UserName, searchedPerson.UserName);
        }

        [Test]  
        public void CheckFindByIDThrowExceptionIfIdIsNegativeNumber()
        {
            var persons = new Person[] { new Person(1, "A"), new Person(2, "B") };
            extendedDatabase = new ExtendedDatabase(persons);
            var searchedId = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                extendedDatabase.FindById(searchedId);

            });
        }

        [Test]
        public void CheckFindByIdThrowExceptonIfNoSuchIdIsFoundInCollection()
        {

            var persons = new Person[] { new Person(1, "A"), new Person(2, "B") };
            extendedDatabase = new ExtendedDatabase(persons);
            var person = new Person(0, "A");
            var personId = person.Id;

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.FindById(personId);
            });
        }

        [Test]
        public void CheckFindByIdWorksCorrect()
        {
            var persons = new Person[] { new Person(1, "A"), new Person(2, "B") };
            extendedDatabase = new ExtendedDatabase(persons);
            var person = new Person(1, "A");
            var personId = person.Id;

            var searchedPerson = extendedDatabase.FindById(personId);

            Assert.AreEqual(person.Id, searchedPerson.Id);
        }
    }
}