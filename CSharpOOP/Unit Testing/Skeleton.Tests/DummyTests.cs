using NUnit.Framework;

[TestFixture]
public class DummyTests
{    
    private int health;
    private int experience;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {        
        this.health = 50;
        this.experience = 6;

        this.dummy = new Dummy(health, experience);
    }

    [Test]
    public void When_HealthIsProvided_ShouldBeSetCorrectly()
    {
        Assert.That(dummy.Health, Is.EqualTo(health));
    }

    [Test]
    public void When_Attacked_ShouldDecreaseHealth()
    {
        int attackPoints = 2;
        dummy.TakeAttack(attackPoints);
        Assert.That(dummy.Health, Is.EqualTo(health - attackPoints));
    }

    [Test]
    public void When_HealthIsPositive_ShouldBeAllive()
    {
        Assert.That(dummy.IsDead, Is.EqualTo(false));
    }

    [Test]
    public void When_HealthIsZero_ShouldBeDead()
    {
        dummy = new Dummy(0, experience);

        Assert.That(dummy.IsDead, Is.EqualTo(true));
    }

    [Test]
    public void When_HealthIsNegative_ShouldBeDead()
    {
        dummy = new Dummy(-1, experience);

        Assert.That(dummy.IsDead, Is.EqualTo(true));
    }

    [Test]
    public void When_AttackedDummyIsDead_ShouldThrowException()
    {
        dummy = new Dummy(-1, experience);

        Assert.That(() => dummy.TakeAttack(3), 
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void When_Dead_ShouldGeveExperience()
    {
        dummy = new Dummy(-1, experience);

        Assert.That(dummy.GiveExperience(), Is.EqualTo(experience));
    }

    [Test]
    public void When_Dead_ShouldThrowException()
    {        
        Assert.That(() => dummy.GiveExperience(),
           Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
