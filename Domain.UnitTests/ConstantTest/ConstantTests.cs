using AutoTrading.Domain.Exceptions;
using AutoTrading.Domain.Generated;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.UnitTests.ConstantTest;

public class ConstantTests
{
    [Test]
    public void 코드_리턴()
    {
        var 국내_1100 = C._11_국내;

        국내_1100.Should().Be(1100);
    }

    [Test]
    public void C와CodeCategory비교()
    {
        var 국내_1100 = C._11_국내;

        (국내_1100 / 10).Should().Be(CodeCategory.토큰분류_10);
    }
}