using NUnit.Framework;
using System.Collections.Generic;
using ONP_konwerter;

namespace ONP;

public class Tests
{
    private Converter _converter;

    [SetUp]
    public void Setup()
    {
        _converter = new Converter();
    }

    [Test]
    public void TestSimpleAddition()
    {
        var result = _converter.PrerpareOperation("2+3");
        var expected = new List<string> { "2", "3", "+" };
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestAdditionWithParentheses()
    {
        var result = _converter.PrerpareOperation("(2+3)");
        var expected = new List<string> { "2", "3", "+" };
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestMixedOperators()
    {
        var result = _converter.PrerpareOperation("2+3*4");
        var expected = new List<string> { "2", "3", "4", "*", "+" };
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestComplexExpression()
    {
        var result = _converter.PrerpareOperation("2+(3*4)-5");
        var expected = new List<string> { "2", "3", "4", "*", "+", "5", "-" };
        Assert.AreEqual(expected, result);
    }
}
