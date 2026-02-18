using Calculator;

namespace Tests;

public class BranchCoverageTests
{
    [Test]
    public void Factorial_Negative_Throws()
    {
        var calc = new SimpleCalculator();
        Assert.Throws<ArgumentException>(() => calc.Factorial(-1));
    }

    [Test]
    public void Factorial_Zero_Returns1()
    {
        var calc = new SimpleCalculator();
        Assert.That(calc.Factorial(0), Is.EqualTo(1));
    }

    [Test]
    public void Factorial_Five_Returns120()
    {
        var calc = new SimpleCalculator();
        Assert.That(calc.Factorial(5), Is.EqualTo(120));
    }

    [Test]
    public void IsPrime_LessThan2_ReturnsFalse()
    {
        var calc = new SimpleCalculator();
        Assert.That(calc.IsPrime(1), Is.False);
    }

    [Test]
    public void IsPrime_Composite_ReturnsFalse()
    {
        var calc = new SimpleCalculator();
        Assert.That(calc.IsPrime(9), Is.False);
    }

    [Test]
    public void IsPrime_Prime_ReturnsTrue()
    {
        var calc = new SimpleCalculator();
        Assert.That(calc.IsPrime(7), Is.True);
    }

    [Test]
    public void CachedCalculator_Add_CacheHit_DoesNotGrowCache()
    {
        var calc = new CachedCalculator();

        calc.Add(2, 3);
        var cacheCountAfterFirst = calc.CacheCount;

        calc.Add(2, 3);
        var cacheCountAfterSecond = calc.CacheCount;

        Assert.That(cacheCountAfterFirst, Is.EqualTo(1));
        Assert.That(cacheCountAfterSecond, Is.EqualTo(1));
    }

    [Test]
    public void Divide_ByZero_Throws()
    {
        var calc = new SimpleCalculator();
        Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
    }

    [Test]
    public void IsPrime_Two_ReturnsTrue()
    {
        var calc = new SimpleCalculator();
        Assert.That(calc.IsPrime(2), Is.True);
    }

    [Test]
    public void IsPrime_SquareOfPrime_ReturnsFalse()
    {
        var calc = new SimpleCalculator();
        Assert.That(calc.IsPrime(25), Is.False);
    }

    [Test]
    public void CachedCalculator_Factorial_CacheHit_DoesNotGrowCache()
    {
        var calc = new CachedCalculator();

        calc.Factorial(5);
        var afterFirst = calc.CacheCount;

        calc.Factorial(5);
        var afterSecond = calc.CacheCount;

        Assert.That(afterFirst, Is.EqualTo(1));
        Assert.That(afterSecond, Is.EqualTo(1));
    }
}
