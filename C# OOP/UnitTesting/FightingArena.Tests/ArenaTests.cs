using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    class ArenaTests
    {
        private Warrior warrior;
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }
        [Test]

        public void EnrollShouldAddWarriorToTheArena()

        {

            Warrior warrior1 = new Warrior("Warrior", 5, 50);

            this.arena.Enroll(warrior1);

            Assert.That(this.arena.Warriors, Has.Member(warrior1));

        }
        [Test]
        public void CheckCollectionInConstructorIsNotNull()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void CheckConstructorWorksCorrect()
        {
            var arena = new Arena();

            warrior = new Warrior("Wolf", 100, 1000);
            var warrior2 = new Warrior("Bear", 100, 2000);
           
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            var expectedCount = 2;
            var realCount = arena.Count;

            Assert.AreEqual(expectedCount, realCount);
        }
        [Test]
        public void CheckEnrollThrowsExceptionIfThereAlreadySameWarriorEnrolled()
        {
            var arena = new Arena();

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior = new Warrior("Wolf", 100, 1000);
                var warrior2 = new Warrior("Wolf", 100, 2000);

                arena.Enroll(warrior);
                arena.Enroll(warrior2);
            });
        }
        [Test]
        public void CheckFightThrowsExceptionIfDefenderIsNotEnrolled()
        {
            var arena = new Arena();
           var attacker = new Warrior("Wolf", 100, 1000);
            var deffender = new Warrior("Bear", 100, 2000);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attacker.Name, deffender.Name);
            });
        }

        [Test]
        public void CheckFightThrowsExceptionIfAttackerIsNotEnrolled()
        {
            var arena = new Arena();
            var attacker = new Warrior("Wolf", 100, 1000);
            var deffender = new Warrior("Bear", 100, 2000);

            arena.Enroll(deffender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attacker.Name, deffender.Name);
            });
        }

        [Test]
        public void CheckFightWorksCorrect()
        {
            var arena = new Arena();
            var attacker = new Warrior("Wolf", 100, 1000);
            var deffender = new Warrior("Bear", 100, 2000);

            arena.Enroll(attacker);
            arena.Enroll(deffender);

            arena.Fight(attacker.Name, deffender.Name);

            var expectedAttakerHp = 900;
            var expectedDeffenderHp = 1900;

            var realAttakerHp = attacker.HP;
            var realDeffenderHp = deffender.HP;

            Assert.AreEqual(expectedAttakerHp, realAttakerHp);
            Assert.AreEqual(expectedDeffenderHp, realDeffenderHp);
        }

        [Test]
        public void CheckWarriorsCollectionWorkCorrect()
        {
            var arena = new Arena();
            var attacker = new Warrior("Wolf", 100, 1000);
            var deffender = new Warrior("Bear", 100, 2000);

            arena.Enroll(attacker);
            arena.Enroll(deffender);

            var warriorsList = new List<Warrior>();
            warriorsList.Add(attacker);
            warriorsList.Add(deffender);

            CollectionAssert.AreEqual(warriorsList, arena.Warriors);
        }
    }
}
