using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack;
    private int durability;
    private int health;
    private int experience;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.attack = 5;
        this.durability = 6;
        this.health = 50;
        this.experience = 6;

        this.axe = new Axe(attack, durability);
        this.dummy = new Dummy(health, experience);
    }

    [Test]
    public void When_AxeAttackAndDurabilityProvided_ShouldBeSetCorrectly()
    {

        Assert.AreEqual(attack, axe.AttackPoints);
        Assert.AreEqual(durability, axe.DurabilityPoints);
    }

    [Test]
    public void When_AxeAttacks_ShouldLoseDurabilityPoints()
    {
        this.axe.Attack(this.dummy);

        Assert.AreEqual(durability - 1, axe.DurabilityPoints);
    }

    [Test]
    public void When_AxeAttacksWithZeroDurabilityPoints_ShouldThrowException()
    {
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                this.axe.Attack(this.dummy);
            }
        });

        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }

    [Test]
    public void When_AxeAttackIsCalledWithNullDummy_ShouldThrowNullReference()
    {
        Assert.Throws<NullReferenceException>(() => axe.Attack(null));
    }
}