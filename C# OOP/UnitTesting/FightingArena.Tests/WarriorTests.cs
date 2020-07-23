using System;
using NUnit.Framework;

namespace Tests

{
    public class WarriorTests
    {
        private Warrior warrior;
        private const int MIN_ATK_HP = 30;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CheckWheterConstructorWorksCorrect()
        {
            warrior = new Warrior("Wolf", 100, 1000);
            var expectedName = "Wolf";
            var expectedDamage = 100;
            var expectedHp = 1000;
            var realName = warrior.Name;
            var realDmg = warrior.Damage;
            var realHp = warrior.HP;

            Assert.AreEqual(expectedName, realName);
            Assert.AreEqual(expectedDamage, realDmg);
            Assert.AreEqual(expectedHp, realHp);
        }

        [Test]
        public void CheckWheterNameThrowsExceptionIfValueIsEmpty()
        {
           string name = string.Empty;
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, 100, 1000);
            });
        }
        [Test]
        public void CheckWheterNameThrowsExceptionIfValueIsNull()
        {
            string name = null;
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, 100, 1000);
            });
        }
        [Test]
        public void CheckWheterNameThrowsExceptionIfValueIsWhiteSpace()
        {
            string name = " ";
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, 100, 1000);
            });
        }

        [Test]
        
        public void CheckDamageThrowsExceptionIfValueIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Wolf", 0, 1000);
            });
        }
        [Test]

        public void CheckDamageThrowsExceptionIfValueIsNeganive()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Wolf", -1, 1000);
            });
        }

        [Test]
        public void CheckHpThrowsExceptionIfValueIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Wolf", 100, -1);
            });
        }

        [Test]
       [TestCase(10)]
       [TestCase(30)]
        public void CheckAttackThrowsExceptionIfHpIsLessOrEqaulToMIN_ATK_HP(int hp)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior = new Warrior("Wolf", 100, hp);
                var secondWarrior = new Warrior("Bear", 100, 2000);
                warrior.Attack(secondWarrior);
            });
        }

        
        [Test]
        [TestCase(10)]
        [TestCase(30)]
        public void CheckAttackThrowsExceptionIfHeTryToAttackAnotherWarriorWhichHpIsLessThanOrEqualMIN_ATK_HP(int hp)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior = new Warrior("Wolf", 100, 1000);
                var secondWarrior = new Warrior("Bear", 100, hp);
                warrior.Attack(secondWarrior);
            });
        }
       
        [Test]
        public void CheckAttackThrowsExceptionIfTryToAttackOtherWarriorWhichDmgIsGreaterThanWarriorsHp()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior = new Warrior("Wolf", 100, 99);
                var secondWarrior = new Warrior("Bear", 100, 2000);
                warrior.Attack(secondWarrior);
            });
        }

        [Test]
        [TestCase(22, 40)]
        [TestCase(49, 40)]
        [TestCase(50, 40)]
        public void WarriorTest_Atacks_Correctly(int dmg, int hp)
        {
            Warrior attacker = new Warrior("Bai Ivan", dmg, hp);
            Warrior defender = new Warrior("Bai Pesho", 20, 50);

            attacker.Attack(defender);

            int expected = 50 - dmg;
            int actual = defender.HP;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(51, 40)]
        [TestCase(52, 40)]
        [TestCase(120, 40)]
        public void WarriorTest_Atacks_Correctly_WithMoreDamage(int dmg, int hp)
        {
            Warrior attacker = new Warrior("Bai Ivan", dmg, hp);
            Warrior defender = new Warrior("Bai Pesho", 20, 50);

            attacker.Attack(defender);

            int expected = 0;
            int actual = defender.HP;

            Assert.AreEqual(expected, actual);
        }
    }
}