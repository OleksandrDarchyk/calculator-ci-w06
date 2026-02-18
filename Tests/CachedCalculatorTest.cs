using Calculator;

namespace Tests;

public class CachedCalculatorTest
{
    [Test]
    public void Add()
    {
        var calc = new CachedCalculator();
        var result = calc.Add(2, 3);

        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void CachedCalculator_DifferentArguments_CreateDifferentCacheEntries()
    {
        var calc = new CachedCalculator();

        calc.Add(2, 3);
        calc.Add(3, 2);

        Assert.That(calc.CacheCount, Is.EqualTo(2));
    }

    [Test]
    public void Subtract_ReturnsCorrectResult()
    {
        var calc = new SimpleCalculator();
        Assert.That(calc.Subtract(5, 3), Is.EqualTo(2));
    }

    [Test]
    public void Multiply_ReturnsCorrectResult()
    {
        var calc = new SimpleCalculator();
        Assert.That(calc.Multiply(4, 3), Is.EqualTo(12));
    }

    [Test]
    public void Divide_ReturnsCorrectResult()
    {
        var calc = new SimpleCalculator();
        Assert.That(calc.Divide(10, 2), Is.EqualTo(5));
    }

    [Test]
    public void CachedCalculator_ReturnsSameResult_FromCache()
    {
        var calc = new CachedCalculator();

        var first = calc.Add(2, 3);
        var second = calc.Add(2, 3);

        Assert.That(first, Is.EqualTo(second));
    }
}